import os
from io import BytesIO
from PIL import Image
import pytesseract
import fitz  
from pdf2image import convert_from_bytes
from langchain.text_splitter import RecursiveCharacterTextSplitter

from ..services.vector_engine import collection, embedding_model


def extract_text_mixed_pdf(pdf_bytes):
    """Handles digital + scanned PDFs by checking each page."""
    full_text = ""
    pdf = fitz.open("pdf", pdf_bytes)

    for i, page in enumerate(pdf):
        text = page.get_text().strip()
        if text:
            full_text += f"\n[Page {i+1} - Digital]\n{text}"
        else:
            image = convert_from_bytes(pdf_bytes, first_page=i+1, last_page=i+1)[0]
            ocr_text = pytesseract.image_to_string(image, config='--psm 6').strip()  # Adjust page segmentation mode for better OCR
            full_text += f"\n[Page {i+1} - OCR]\n{ocr_text}"
    return full_text


def segment_text(text):
    """Split long text into chunks for embedding."""
    text_splitter = RecursiveCharacterTextSplitter(chunk_size=1000, chunk_overlap=200)
    return text_splitter.split_text(text)


def process_pdf_stream(pdf_bytes, pdf_name):
    # 1. Check if already exists
    existing_docs = collection.query(query_texts=[pdf_name], n_results=1)
    if existing_docs["documents"]:
        print(f"PDF '{pdf_name}' already exists in DB. Overwriting...")
        collection.delete(where={"source": pdf_name})

    # 2. Extract text (handles mixed types)
    print(f"Processing '{pdf_name}' as mixed (digital + scanned) PDF...")
    text = extract_text_mixed_pdf(pdf_bytes)

    if not text.strip():
        print(f"Failed to extract any useful text from '{pdf_name}'.")
        return

    # 3. Chunk & Embed
    chunks = segment_text(text)
    chunk_embeddings = embedding_model.embed_documents(chunks)

    for idx, chunk in enumerate(chunks):
        collection.add(
            ids=[f"{pdf_name}_{idx}"],
            metadatas=[{"source": pdf_name, "chunk_id": idx}],
            documents=[chunk]
        )

    print(f" Stored {len(chunks)} chunks from '{pdf_name}'.")
