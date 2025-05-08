
from pydantic import BaseModel
from typing import List

class Employee(BaseModel):
    Id: str
    FirstName: str
    LastName: str
    UserName: str
    Email: str
    Experience: int
    Department: str
    Designation: str
    Skills: List[str]
    Proficiencies: List[str]
    ProjectStatus: str  
    AssignibilityPerncentage: int
    BillablePerncentage: int
    AvailabilityPerncentage: int  

class TeamRecommendationRequest(BaseModel):
    Description: str
    Employees: List[Employee]
