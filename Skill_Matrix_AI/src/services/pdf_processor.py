# import os
# # from pypdf import PdfReader
# from langchain.text_splitter import RecursiveCharacterTextSplitter
# from ..services.vector_engine import collection, embedding_model
# from io import BytesIO
# import pytesseract
# from pdf2image import convert_from_bytes
# from PIL import Image
# from PyPDF2 import PdfReader


# def extract_text_from_bytes(pdf_bytes):
#     reader = PdfReader(BytesIO(pdf_bytes))
#     text = "\n".join([page.extract_text() for page in reader.pages if page.extract_text()])
#     return text


# def extract_text_with_ocr(pdf_bytes):
#     images = convert_from_bytes(pdf_bytes)
#     text = "\n".join(pytesseract.image_to_string(img) for img in images)
#     return text.strip()



# def segment_text(text):
#     text_splitter = RecursiveCharacterTextSplitter(chunk_size=500, chunk_overlap=50)
#     return text_splitter.split_text(text)


# def process_pdf_stream(pdf_bytes, pdf_name):
#     # Check if the PDF already exists in the vector database
#     existing_docs = collection.query(query_texts=[pdf_name], n_results=1)  # Use query_texts

#     if existing_docs["documents"]:
#         print(f"PDF '{pdf_name}' already exists in the database. Overwriting existing data.")
#         # Delete existing documents from the database before inserting new ones
#         collection.delete(where={"source": pdf_name})

#     # Try normal text extraction
#     text = extract_text_from_bytes(pdf_bytes)

#     # Fallback to OCR if no text found
#     if not text:
#         print(f"No text found in '{pdf_name}', using OCR...")
#         text = extract_text_with_ocr(pdf_bytes)

#     # Final check
#     if not text:
#         print(f"Failed to extract any text from '{pdf_name}' using both methods.")
#         return

#     chunks = segment_text(text)
#     chunk_embeddings = embedding_model.embed_documents(chunks)

#     for idx, chunk in enumerate(chunks):
#         collection.add(
#             ids=[f"{pdf_name}_{idx}"],
#             metadatas=[{"source": pdf_name, "chunk_id": idx}],
#             documents=[chunk]
#         )

#     print(f"Stored {len(chunks)} chunks from '{pdf_name}' in ChromaDB.")


import os
from io import BytesIO
from PIL import Image
import pytesseract
from PyPDF2 import PdfReader
from pdf2image import convert_from_bytes
from langchain.text_splitter import RecursiveCharacterTextSplitter

from ..services.vector_engine import collection, embedding_model


def extract_text_from_bytes(pdf_bytes):
    """Extract text from a PDF assuming it's digitally generated."""
    reader = PdfReader(BytesIO(pdf_bytes))
    return "\n".join([page.extract_text() for page in reader.pages if page.extract_text()])


def extract_text_with_ocr(pdf_bytes):
    """Extract text from scanned PDF using OCR."""
    images = convert_from_bytes(pdf_bytes)
    return "\n".join(pytesseract.image_to_string(img) for img in images).strip()


def segment_text(text):
    """Split long text into chunks for embedding."""
    text_splitter = RecursiveCharacterTextSplitter(chunk_size=500, chunk_overlap=50)
    return text_splitter.split_text(text)


def detect_pdf_type(text):
    """Rudimentary check to see if it's digital or needs OCR."""
    if not text or len(text.strip()) < 50:
        return "scanned"
    elif len(text.strip()) < 500:
        return "mixed"
    return "digital"


def process_pdf_stream(pdf_bytes, pdf_name):
    # 1. Check if already exists
    existing_docs = collection.query(query_texts=[pdf_name], n_results=1)
    if existing_docs["documents"]:
        print(f"PDF '{pdf_name}' already exists in DB. Overwriting...")
        collection.delete(where={"source": pdf_name})

    # 2. Try normal extraction
    text = extract_text_from_bytes(pdf_bytes)
    pdf_type = detect_pdf_type(text)

    if pdf_type == "scanned":
        print(f"'{pdf_name}' appears to be a scanned PDF. Using OCR...")
        text = extract_text_with_ocr(pdf_bytes)
    elif pdf_type == "mixed":
        print(f"'{pdf_name}' seems to contain limited digital text. Using OCR as fallback...")
        ocr_text = extract_text_with_ocr(pdf_bytes)
        # Merge digital + OCR
        text = text + "\n" + ocr_text

    # 3. Final validation
    if not text.strip():
        print(f"Failed to extract any useful text from '{pdf_name}'.")
        return

    # 4. Chunk & Embed
    chunks = segment_text(text)
    chunk_embeddings = embedding_model.embed_documents(chunks)

    for idx, chunk in enumerate(chunks):
        collection.add(
            ids=[f"{pdf_name}_{idx}"],
            metadatas=[{"source": pdf_name, "chunk_id": idx}],
            documents=[chunk]
        )

    print(f" Stored {len(chunks)} chunks from '{pdf_name}' as a '{pdf_type}' PDF.")

