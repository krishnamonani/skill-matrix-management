from fastapi import APIRouter
from ..schemas.team_recommendation_schema import TeamRecommendationRequest
from ..services.team_recommendation_services import recommend_team

router = APIRouter()

@router.post("/recommend-team")
def recommend_team_route(request: TeamRecommendationRequest):
    return recommend_team(request.Description, request.Employees)
