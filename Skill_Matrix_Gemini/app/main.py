import os
from fastapi import FastAPI
from pydantic import BaseModel
from typing import List
from dotenv import load_dotenv
import google.generativeai as genai

# Load environment variables
load_dotenv()

# Gemini API setup
GEMINI_API_KEY = os.getenv("AIzaSyDKojMdJjxYJFpvwMu3lX8TTOHyK0SuL8M")
genai.configure(api_key=GEMINI_API_KEY)

# Initialize FastAPI app
app = FastAPI()

# Request body schema
class SkillRequest(BaseModel):
    role: str
    n:int
    current_skills: List[str]
    

# Skill recommendation logic using Gemini
def generate_skill_recommendation(role: str, n: int ,current_skills: List[str]) -> List[str]:
    # ✅ Handle Empty Skill List Case
    if not current_skills:
        prompt = (
            f"Suggest most important technical or professional skills required for a {role}. "
            f"Respond only with skill names, one per line, without any explanation or numbering."
        )
    else:
        prompt = (
            f"Suggest {n} additional technical skills for a {role}, excluding these: {', '.join(current_skills)}. "
            f"Respond only with skill names, one per line, without any explanation or numbering."
        )

    model = genai.GenerativeModel("gemini-1.5-pro")
    response = model.generate_content(prompt, generation_config=genai.types.GenerationConfig(temperature=0))

    try:
        generated_text = response.text.strip()
        print("🔍 Gemini Response:\n", generated_text)
    except Exception as e:
        print("❌ Failed to parse Gemini response:", e)
        return []

    # Parse and clean skills
    skills = []
    for line in generated_text.splitlines():
        skill = line.strip()
        if any(keyword in skill.lower() for keyword in [
            "suggest", "respond", "exclude", "return", "additional", "skill names", "one per line", "no prefix"
        ]):
            continue
        if skill and skill.lower() not in [s.lower() for s in current_skills]:
            skills.append(skill)

    # Deduplicate and return top 5
    skills = list(dict.fromkeys(skills))
    return skills[:5]

# API route
@app.post("/recommend-skills")
def recommend_skills(request: SkillRequest):
    recommended = generate_skill_recommendation(request.role,request.n, request.current_skills)
    return {"recommended_skills": recommended}

