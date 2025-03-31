from pydantic import BaseModel

class TeamRequest(BaseModel):
    project_name: str
    deadline: str
    required_skills: list
    team_size: int
    role_distribution: dict
    min_experience: int = 0
    availability_hours: int = 40
    diversity_preferences: list = []