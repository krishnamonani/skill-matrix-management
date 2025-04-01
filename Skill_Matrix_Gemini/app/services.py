import os
import google.generativeai as genai
import google  # Import the google module
from fastapi import HTTPException
from typing import List

# Configure Gemini API
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")

if not GEMINI_API_KEY:
    raise RuntimeError("GEMINI_API_KEY is missing! Set it in the environment variables.")

genai.configure(api_key=GEMINI_API_KEY)


def validate_input(Role: str, NumberOfRecommendations: int, Skills: List[str]):
    """Validates input before passing to Gemini API."""
    if not isinstance(Role, str) or not Role.strip():
        raise HTTPException(status_code=422, detail="Invalid Role: Must be a non-empty string.")
    
    if not isinstance(NumberOfRecommendations, int) or NumberOfRecommendations <= 0:
        raise HTTPException(status_code=422, detail="Invalid NumberOfRecommendations: Must be a positive integer.")
    
    if not isinstance(Skills, list) or not all(isinstance(skill, str) for skill in Skills):
        raise HTTPException(status_code=422, detail="Invalid Skills: Must be a list of strings.")
    
    # Remove duplicates from Skills
    Skills[:] = list(set(skill.strip() for skill in Skills if skill.strip()))


def generate_skill_recommendation(Role: str, NumberOfRecommendations: int, Skills: List[str]) -> List[str]:
    """Generates skill recommendations using Gemini AI."""
    
    validate_input(Role, NumberOfRecommendations, Skills)

    # Ensure Role is not empty
    if not Role.strip():
        raise HTTPException(status_code=400, detail="Role cannot be empty.")

    # Create the prompt dynamically
    if Skills:
        prompt = (
            f"Suggest {NumberOfRecommendations} technical skills for a {Role}, "
            f"excluding these: {', '.join(Skills)}. Respond with skill names only, one per line."
        )
    else:
        prompt = (
            f"Suggest {NumberOfRecommendations} most important technical skills for a {Role}. "
            "Respond with skill names only, one per line."
        )

    try:
        model = genai.GenerativeModel("gemini-1.5-pro")
        response = model.generate_content(
            prompt, 
            generation_config=genai.types.GenerationConfig(temperature=0)
        )

        if not response.text:
            raise HTTPException(status_code=500, detail="Received an empty response from Gemini API.")

        # Process skills
        SkillsList = response.text.strip().split("\n")
        return list(dict.fromkeys(skill.strip() for skill in SkillsList if skill))

    except google.api_core.exceptions.InvalidArgument as api_error:
        raise HTTPException(status_code=500, detail=f"API Error: {str(api_error)}")
    
    except google.api_core.exceptions.ResourceExhausted:
        raise HTTPException(status_code=429, detail="Rate limit exceeded. Please try again later.")

    except google.api_core.exceptions.DeadlineExceeded:
        raise HTTPException(status_code=504, detail="Request timed out. Please try again.")

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Unexpected error: {str(e)}")
