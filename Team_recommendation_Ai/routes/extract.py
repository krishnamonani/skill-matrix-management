from fastapi import APIRouter, UploadFile, File, HTTPException
from services.requirement_extraction import extract_requirements_from_text

router = APIRouter()

@router.post("/extract-requirements")
def extract_requirements(file: UploadFile = File(...)):
    try:
        content = file.file.read().decode("utf-8")
        extracted_data = extract_requirements_from_text(content)
        return {"extracted_requirements": extracted_data}
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))