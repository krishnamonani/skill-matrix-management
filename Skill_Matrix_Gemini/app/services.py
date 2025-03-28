import os
import google.generativeai as genai
from fastapi import HTTPException
from typing import List

# Configure Gemini API
genai.configure(api_key=os.getenv("GEMINI_API_KEY"))


def validate_input(Role: str, NumberOfRecommendations: int, Skills: List[str]):
    """Validates input before passing to Gemini API."""
    if not isinstance(Role, str) or not Role.strip():
        raise HTTPException(status_code=422, detail="Invalid Role: Must be a non-empty string.")
    if not isinstance(NumberOfRecommendations, int) or NumberOfRecommendations <= 0:
        raise HTTPException(status_code=422, detail="Invalid NumberOfRecommendations: Must be a positive integer.")
    if not isinstance(Skills, list) or not all(isinstance(skill, str) for skill in Skills):
        raise HTTPException(status_code=422, detail="Invalid Skills: Must be a list of strings.")


def generate_skill_recommendation(Role: str, NumberOfRecommendations: int, Skills: List[str]) -> List[str]:
    validate_input(Role, NumberOfRecommendations, Skills)

    # Create the prompt dynamically
    if Skills:
        prompt = (
            f"Suggest {NumberOfRecommendations} technical skills for a {Role}, "
            f"excluding these: {', '.join(Skills)}. Respond with skill names only, one per line."
        )
    else:
        prompt = (
            f"Suggest the most important technical skills for a {Role}. "
            "Respond with skill names only, one per line."
        )

    try:
        model = genai.GenerativeModel("gemini-1.5-pro")
        response = model.generate_content(
            prompt, 
            generation_config=genai.types.GenerationConfig(temperature=0)
        )

        if not response.text:
            return []

        SkillsList = response.text.strip().split("\n")
        return list(dict.fromkeys(skill.strip() for skill in SkillsList if skill))

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Error generating skills: {str(e)}")
