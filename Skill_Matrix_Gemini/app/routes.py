from fastapi import APIRouter
from app.models import SkillRequest
from app.services import generate_skill_recommendation
from .models import Skill_req

router = APIRouter()

@router.post("/recommend-skills")
def recommend_skills(request: SkillRequest):
    skill= Skill_req(
        role=request.Role,
        number=request.NumberOfRecommendations,
        skills=str(request.Skills),
        experience=str(request.Experience)
    )
    recommended = generate_skill_recommendation(skill)
    return recommended
