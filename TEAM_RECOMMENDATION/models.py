# from pydantic import BaseModel
# from typing import List, Dict

# class SkillLevel(BaseModel):
#     skills: Dict[str, str]

# class Employee(BaseModel):
#     id: str
#     firstName: str
#     lastName: str
#     userName: str
#     email: str
#     experience: int
#     department: str
#     designation: str
#     skills: List[str]
#     proficiencies: List[str]
#     projectStatus: str

# class TeamRecommendationRequest(BaseModel):
#     description: str  # Extracted from SRS or entered directly
#     employees: List[Employee]  # Data from dev backend
from pydantic import BaseModel
from typing import List

class Employee(BaseModel):
    id: str
    firstName: str
    lastName: str
    userName: str
    email: str
    experience: int
    department: str
    designation: str
    skills: List[str]
    proficiencies: List[str]
    projectStatus: str

class TeamRecommendationRequest(BaseModel):
    description: str
    employees: List[Employee]
