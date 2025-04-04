from pydantic import BaseModel
from typing import List

class SkillRequest(BaseModel):
    Role: str
    NumberOfRecommendations: int
    Skills: List[str]
    Experience: str

class Skill_req(BaseModel):
    role: str
    number: int
    skills: str
    experience: str