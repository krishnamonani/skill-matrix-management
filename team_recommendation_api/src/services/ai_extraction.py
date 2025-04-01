import google.generativeai as genai
import json
import re
from src.config import GEMINI_API_KEY

genai.configure(api_key=GEMINI_API_KEY)

def extract_required_skills(project_description):
    """Uses AI to extract required skills from a general project description."""
    model = genai.GenerativeModel("gemini-1.5-pro")
    prompt = (
        "Analyze the given project description and extract key technical skills required. "
        "Return a JSON array with general skill names matching standard database skills. "
        "Example: [\"Python\", \"Machine Learning\", \"FastAPI\", \"PostgreSQL\"]\n\n"
        f"Project Description: {project_description}"
    )

    response = model.generate_content(prompt)
    raw_text = response.text.strip()

    print("🔹 AI Raw Response:", raw_text)

    raw_text = re.sub(r"```json|```", "", raw_text).strip()

    try:
        extracted_skills = json.loads(raw_text)
        if not isinstance(extracted_skills, list):
            raise ValueError("AI response is not a valid JSON list")
    except json.JSONDecodeError:
        raise ValueError(f"Failed to parse AI response as JSON. Raw Response: {raw_text}")

    return extracted_skills
