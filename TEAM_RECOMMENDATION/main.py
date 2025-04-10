# from fastapi import FastAPI
# from routes import router


# app = FastAPI()
# app.include_router(router)

from fastapi import FastAPI
from routes import router

app = FastAPI(
    title="Team Recommendation API",
    description="Recommends optimal project teams based on project requirements and employee data.",
    version="1.0.0"
)

app.include_router(router, prefix="/api")
