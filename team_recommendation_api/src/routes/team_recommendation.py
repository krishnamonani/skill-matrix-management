from fastapi import APIRouter, HTTPException, Query
from src.services.ai_extraction import extract_required_skills
from src.services.employee_fetch import fetch_employees_with_skills
from src.services.ranking import rank_employees

router = APIRouter()

@router.post("/recommend_team/")
def recommend_team(project_description: str = Query(..., title="Project Description")):
    """Receives project description, extracts skills, and recommends the best team."""
    try:
        required_skills = extract_required_skills(project_description)
        if not required_skills:
            raise HTTPException(status_code=400, detail="No skills extracted from description")

        matching_employees = fetch_employees_with_skills(required_skills)
        if not matching_employees:
            raise HTTPException(status_code=404, detail="No suitable employees found")

        ranked_team = rank_employees(matching_employees, required_skills)

        return {"required_skills": required_skills, "recommended_team": ranked_team}

    except HTTPException as http_err:
        raise http_err
    except Exception as e:
        print("Internal Error:", e)
        raise HTTPException(status_code=500, detail="Internal server error")
