from fastapi import APIRouter, HTTPException
from models import TeamRequest
from services.ai import get_matching_employees, generate_team_recommendation

router = APIRouter()

@router.post("/recommend-team")
def recommend_team(request: TeamRequest):
    employees = get_matching_employees(request.required_skills, request.min_experience, request.availability_hours)
    if not employees:
        raise HTTPException(status_code=404, detail="No matching employees found.")
    team_recommendation = generate_team_recommendation(request, employees)
    return {"recommended_team": team_recommendation}