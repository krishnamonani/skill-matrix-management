from fastapi import APIRouter
from models import TeamRecommendationRequest

from services import recommend_team


router = APIRouter()

@router.post("/recommend-team")
def recommend_team_route(request: TeamRecommendationRequest):
    return recommend_team(request.project_description, request.employees)
