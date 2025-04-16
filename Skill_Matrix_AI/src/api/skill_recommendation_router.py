from fastapi import APIRouter
from ..schemas.skill_recommendation_schema import SkillRequest, Skill_req
from ..services.skill_recommendation_services import generate_skill_recommendation

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
