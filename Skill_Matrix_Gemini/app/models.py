from pydantic import BaseModel
from typing import List

class SkillRequest(BaseModel):
    Role: str
    NumberOfRecommendations: int
    Skills: List[str]
