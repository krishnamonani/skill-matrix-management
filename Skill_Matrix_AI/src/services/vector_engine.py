import os
import chromadb
import re
import json
from src.config import GEMINI_API_KEY
import re
import json
from typing import Dict
from pathlib import Path
from langchain_community.vectorstores import Chroma  
from langchain_community.embeddings import SentenceTransformerEmbeddings  
from langchain_google_genai import ChatGoogleGenerativeAI
from langchain.schema import AIMessage  
from langchain.chains import RetrievalQA

# Load API Key
#load_dotenv()
GOOGLE_API_KEY = GEMINI_API_KEY

# Initialize Embeddings & LLM
model_name = "sentence-transformers/all-MiniLM-L6-v2"
embedding_model = SentenceTransformerEmbeddings(model_name=model_name)
# llm = ChatGoogleGenerativeAI(model="gemini-1.5-pro-002", google_api_key=GOOGLE_API_KEY)
llm = ChatGoogleGenerativeAI(
    model="gemini-1.5-pro-002",
    google_api_key=GOOGLE_API_KEY,
    convert_system_message_to_human=True
)

# Initialize ChromaDB
VECTOR_DB_DIR = Path("vector_db")
VECTOR_DB_DIR.mkdir(parents=True, exist_ok=True)

VECTOR_DB_PATH = str(VECTOR_DB_DIR / "chroma.sqlite3")
chroma_client = chromadb.PersistentClient(path=VECTOR_DB_PATH)
collection = chroma_client.get_or_create_collection(name="pdf_embeddings")

retriever = Chroma(persist_directory=VECTOR_DB_PATH, embedding_function=embedding_model).as_retriever()
qa_chain = RetrievalQA.from_chain_type(llm, retriever=retriever)

# Function to clean and structure LLM response
def clean_and_structure_response(response, question):
    if "No relevant information" in response:
        return {
            "question": question,
            "answer": "No relevant information was found for this question.",
            "page_numbers": [],
            "matched_chunks": {}
        }

    # Extract answer
    answer_match = re.search(r"Answer:\s*(.*?)\n", response, re.DOTALL)
    answer = answer_match.group(1).strip() if answer_match else ""

    # Extract page numbers
    page_match = re.search(r"Page Number\(s\):\s*(.*?)\n", response)
    page_numbers = [int(p.strip()) for p in page_match.group(1).split(",")] if page_match else []

    # Extract matched chunks
    matched_chunks_section = re.search(r"Matched Chunks:\s*(.*)", response, re.DOTALL)
    matched_chunks = {}
    if matched_chunks_section:
        lines = matched_chunks_section.group(1).strip().split("\n")
        for line in lines:
            chunk_match = re.match(r"(\d+):\s*\"(.*?)\"", line)
            if chunk_match:
                page = chunk_match.group(1)
                chunk_text = chunk_match.group(2).replace("\n", " ").strip()
                matched_chunks.setdefault(page, []).append(chunk_text)

    return {
        "question": question,
        "answer": answer,
        "page_numbers": page_numbers,
        "matched_chunks": matched_chunks
    }

# Search in ChromaDB
def search_chroma(question, pdf_name):
    query_embedding = embedding_model.embed_query(question)
    results = collection.query(
        query_embeddings=[query_embedding],
        n_results=5,
        where={"source": pdf_name}
    )

    retrieved_chunks = [doc for doc in results['documents'][0]] if results["documents"] else []
    print(f" Retrieved {len(retrieved_chunks)} chunks from '{pdf_name}' for question: {question}")

    return retrieved_chunks



def get_answer(question, relevant_chunks: list) -> Dict:
    if not relevant_chunks:
        return {
            "question": question,
            "answer": "No relevant information was found for this question."
        }

    context = "\n".join(relevant_chunks)

    prompt = f"""
You are an intelligent AI assistant. Answer the question strictly based on the provided context.

Only return the final answer. Do not include page numbers or matched chunks.

If the answer is not found in the context, reply:  
**'No relevant information was found for this question.'**

Context:  
{context}

Question:  
{question}
"""

    response = qa_chain.run(prompt)
    print("\n Raw LLM Response:\n", response)

    # Just extract answer — everything else is ignored
    answer_match = re.search(r"Answer:\s*(.*)", response, re.DOTALL)
    final_answer = answer_match.group(1).strip() if answer_match else response.strip()

    return {
        "question": question,
        "answer": final_answer
    }



