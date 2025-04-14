from pydantic import BaseModel
from typing import List, Dict

class PDFUploadRequest(BaseModel):
    pdf_name: str

class QuestionRequest(BaseModel):
    question: str
    pdf_name: str

class AnswerResponse(BaseModel):
    question: str
    answer: str
  