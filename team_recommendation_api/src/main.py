from fastapi import FastAPI
from src.routes.team_recommendation import router

app = FastAPI()

# Include routes
app.include_router(router)

@app.get("/")
def root():
    return {"message": "Welcome to the Team Recommendation API!"}
