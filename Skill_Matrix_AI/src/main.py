from fastapi import FastAPI
# from .api.skill_recommendation_router import router
# from .api.pdfQnA_router import router
from .api.skill_recommendation_router import router as skill_router
from .api.pdfQnA_router import router as pdf_router 
from .api.team_recommendation_router import router as team_router


app = FastAPI()
app.include_router(skill_router)
# app.include_router(router)
app.include_router(pdf_router)
app.include_router(team_router)