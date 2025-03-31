import json
import google.generativeai as genai  

def extract_requirements_from_text(content):
    prompt = f"""
    Extract the key skills, roles, and constraints from the following project requirements document:
    {content}
    Format the response as JSON with 'skills', 'roles', and 'constraints'.
    """
    response = genai.generate_text(model="gemini-1.5-flash", prompt=prompt)
    return json.loads(response.text)

# routes/recommend.py
from fastapi import APIRouter, HTTPException
from models import TeamRequest
from services.team_recommendation import get_matching_employees, generate_team_recommendation

router = APIRouter()

@router.post("/recommend-team")
def recommend_team(request: TeamRequest):
    employees = get_matching_employees(request.required_skills, request.min_experience, request.availability_hours)
    if not employees:
        raise HTTPException(status_code=404, detail="No matching employees found.")
    team_recommendation = generate_team_recommendation(request, employees)
    return {"recommended_team": team_recommendation}
