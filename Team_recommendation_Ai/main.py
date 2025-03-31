from fastapi import FastAPI
from routes import recommend, extract, new_ai_route

app = FastAPI()
app.include_router(recommend.router)
app.include_router(extract.router)
app.include_router(new_ai_route.router)