import os
from pypdf import PdfReader
from langchain.text_splitter import RecursiveCharacterTextSplitter
from ..services.vector_engine import collection, embedding_model
from io import BytesIO
import pytesseract
from pdf2image import convert_from_bytes
from PIL import Image



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
#     # Try normal text extraction
#     text = extract_text_from_bytes(pdf_bytes)

#     # Fallback to OCR if no text found
#     if not text:
#         print(f"No text found in '{pdf_name}', using OCR...")
#         text = extract_text_with_ocr(pdf_bytes)

#     # Final check
#     if not text:
#         print(f" Failed to extract any text from '{pdf_name}' using both methods.")
#         return

#     chunks = segment_text(text)
#     chunk_embeddings = embedding_model.embed_documents(chunks)

#     for idx, chunk in enumerate(chunks):
#         collection.add(
#             ids=[f"{pdf_name}_{idx}"],
#             metadatas=[{"source": pdf_name, "chunk_id": idx}],
#             documents=[chunk]
#         )

#     print(f" Stored {len(chunks)} chunks from '{pdf_name}' in ChromaDB.")


import os
from pypdf import PdfReader
from langchain.text_splitter import RecursiveCharacterTextSplitter
from ..services.vector_engine import collection, embedding_model
from io import BytesIO
import pytesseract
from pdf2image import convert_from_bytes
from PIL import Image


def extract_text_from_bytes(pdf_bytes):
    reader = PdfReader(BytesIO(pdf_bytes))
    text = "\n".join([page.extract_text() for page in reader.pages if page.extract_text()])
    return text


def extract_text_with_ocr(pdf_bytes):
    images = convert_from_bytes(pdf_bytes)
    text = "\n".join(pytesseract.image_to_string(img) for img in images)
    return text.strip()


def segment_text(text):
    text_splitter = RecursiveCharacterTextSplitter(chunk_size=500, chunk_overlap=50)
    return text_splitter.split_text(text)


def process_pdf_stream(pdf_bytes, pdf_name):
    # Check if the PDF already exists in the vector database
    existing_docs = collection.query(query_texts=[pdf_name], n_results=1)  # Use query_texts

    if existing_docs["documents"]:
        print(f"PDF '{pdf_name}' already exists in the database. Overwriting existing data.")
        # Delete existing documents from the database before inserting new ones
        collection.delete(where={"source": pdf_name})

    # Try normal text extraction
    text = extract_text_from_bytes(pdf_bytes)

    # Fallback to OCR if no text found
    if not text:
        print(f"No text found in '{pdf_name}', using OCR...")
        text = extract_text_with_ocr(pdf_bytes)

    # Final check
    if not text:
        print(f"Failed to extract any text from '{pdf_name}' using both methods.")
        return

    chunks = segment_text(text)
    chunk_embeddings = embedding_model.embed_documents(chunks)

    for idx, chunk in enumerate(chunks):
        collection.add(
            ids=[f"{pdf_name}_{idx}"],
            metadatas=[{"source": pdf_name, "chunk_id": idx}],
            documents=[chunk]
        )

    print(f"Stored {len(chunks)} chunks from '{pdf_name}' in ChromaDB.")