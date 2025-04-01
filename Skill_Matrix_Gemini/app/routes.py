from fastapi import APIRouter
from app.models import SkillRequest
from app.services import generate_skill_recommendation

router = APIRouter()

@router.post("/recommend-skills")
def recommend_skills(request: SkillRequest):
    recommended = generate_skill_recommendation(request.Role, request.NumberOfRecommendations, request.Skills)
    return {"RecommendedSkills": recommended}
