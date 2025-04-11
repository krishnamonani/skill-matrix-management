from fastapi import FastAPI
from .api.skill_recommendation_router import router

app = FastAPI()
app.include_router(router)