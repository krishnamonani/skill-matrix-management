from pydantic import BaseModel, RootModel
from typing import List, Dict

class SkillLevel(RootModel[Dict[str, str]]):
    pass

class Employee(BaseModel):
    id: str
    firstName: str
    lastName: str
    userName: str
    email: str
    experience: int
    department: str
    designation: str
    skills: List[SkillLevel]
    projectStatus: str

class TeamRecommendationRequest(BaseModel):
    project_description: str  # Extracted from SRS or entered directly
    employees: List[Employee]  # Data from dev backend
