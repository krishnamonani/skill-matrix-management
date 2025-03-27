from pydantic import BaseModel
from typing import List

class SkillRequest(BaseModel):
    role: str
    n: int
    current_skills: List[str]
