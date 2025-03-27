import google.generativeai as genai
from app.config import GEMINI_API_KEY

# Configure Gemini API
genai.configure(api_key=GEMINI_API_KEY)

def generate_skill_recommendation(role: str, n: int, current_skills: list) -> list:
    prompt = (
        f"Suggest {n} technical skills for a {role}, excluding these: {', '.join(current_skills)}. "
        "Respond with skill names only, one per line."
    ) if current_skills else (
        f"Suggest the most important technical skills for a {role}. "
        "Respond with skill names only, one per line."
    )

    model = genai.GenerativeModel("gemini-1.5-pro")
    response = model.generate_content(prompt, generation_config=genai.types.GenerationConfig(temperature=0))

    try:
        skills = response.text.strip().split("\n")
        return list(dict.fromkeys(skill.strip() for skill in skills if skill))
    except Exception:
        return []
