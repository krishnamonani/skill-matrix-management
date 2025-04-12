from fastapi import APIRouter, UploadFile, File, Form
from ..schemas.pdfQnA_schema import QuestionRequest, AnswerResponse
from ..services.pdf_processor import process_pdf_stream
from ..services.vector_engine import search_chroma, get_answer

router = APIRouter()

@router.post("/upload_pdf/")
async def upload_pdf(file: UploadFile = File(...), pdf_name: str = Form(...)):
    pdf_bytes = await file.read()
    process_pdf_stream(pdf_bytes, pdf_name)
    return {"message": f"PDF '{pdf_name}' successfully processed and stored in vector DB."}


@router.post("/ask", response_model=AnswerResponse)
async def ask_question(request: QuestionRequest):
    relevant_chunks = search_chroma(request.question, request.pdf_name)
    answer_data = get_answer(request.question, relevant_chunks)
    return AnswerResponse(
    question=answer_data["question"],
    answer=answer_data["answer"]
)
