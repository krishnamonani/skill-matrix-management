import os
import google.generativeai as genai
from fastapi import HTTPException
from typing import List
from .models import Skill_req
from dotenv import load_dotenv
import json

load_dotenv()


# Configure Gemini API
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")

if not GEMINI_API_KEY:
    raise RuntimeError("GEMINI_API_KEY is missing! Set it in the environment variables.")

genai.configure(api_key=GEMINI_API_KEY)


import json
import re

def generate_skill_recommendation(skill: Skill_req):
    """Generates skill recommendations using Gemini AI."""
    
    generation_config = {
        "temperature": 0.5,
        "top_p": 0.95,
        "top_k": 40,
        "max_output_tokens": 8192,
        "response_mime_type": "text/plain",
    }

    model = genai.GenerativeModel(
        model_name="gemini-1.5-flash",
        generation_config=generation_config,
        system_instruction=(
            ''' Input Format:
The system will receive the following inputs:  
1. Number of new Required Skills – The number of additional skills the user wants to learn.  
2. Current Skills – A list of skills the user is already proficient in.  
3. Role – The user's job role, which should be considered when recommending new skills.  
4. Experience (in years) – The user’s experience level, which helps tailor skill recommendations.  
You are a professional career and technical skill recommender.

Your job is to suggest only **new, high-impact, role-relevant technical skills** that align with the user's job role, years of experience, and current skill set.

 Guidelines:
- Recommend only **technical**, **hands-on**, and **advanced skills** (tools, frameworks, languages, architectures, methodologies).
- DO NOT suggest any of the following unless explicitly asked: soft skills, leadership, Agile, communication, cloud basics, time management, or team collaboration.
- DO NOT suggest skills that are already present in the user's current skills or minor variations (e.g., avoid TypeScript if JavaScript is listed).
- For senior professionals (5+ years), suggest **advanced, specialized, and cross-domain skills** relevant to their role.
- For users with 10+ years experience, focus on **architectural, strategic, or domain-expanding technical skills**.
- For junior users (<3 years), suggest **foundational, emerging, or in-demand technical skills**.
- If the role is niche (e.g., AI in Healthcare), recommend **industry-specific or cross-functional technical skills**.
- Avoid introductory skills unless absolutely essential for the user’s role and career growth.
- Each recommended skill must be **distinct, impactful**, and **expand the user's technical horizon**, not just incrementally improve what they already know. 
- Do NOT suggest technical skills that are internal components, wrappers, or closely nested within each other.
Examples: If 'TensorFlow' is recommended, do NOT also recommend 'Keras' (it's part of TensorFlow). If 'JavaScript' is known, avoid 'TypeScript' unless the use case is very different. If 'PyTorch' is suggested, skip 'TorchVision' unless it introduces new functionality.
Each skill must introduce a clearly distinct area of technical capability.
Recommend only role-relevant technical skills.

Do NOT suggest DevOps or general infrastructure tools (like Docker, Kubernetes, Terraform, CI/CD, Jenkins, etc.) unless the user’s role is explicitly related to MLOps, DevOps, or deployment.

For AI/ML roles, prioritize modeling, deep learning, optimization, data pipelines, explainability, federated learning, transformers, etc. over deployment and infra skills.
Output Format:  
The system should return a JSON object with list of skills and corresponding list of reasons.

 '''
        ),
    )

    chat_session = model.start_chat(
  history=[
    {
      "role": "user",
      "parts": [
        "{\n  \"number_of_new_required_skills\": 3,\n  \"current_skills\": [\"Python\", \"Pandas\", \"SQL\"],\n  \"role\": \"Data Analyst\",\n  \"experience\": 2\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": [\"Data Visualization with Tableau\", \"Data Storytelling\", \"Statistical Modeling\"],\n  \"reasons\": [\n    \"Tableau is a widely used data visualization tool that will enhance your ability to communicate insights effectively.\",\n    \"Data storytelling is crucial for conveying complex data analyses to non-technical audiences and stakeholders.\",\n    \"Statistical modeling provides a deeper understanding of data and improves predictive capabilities, expanding your analytical toolkit beyond basic descriptive statistics.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"number_of_new_required_skills\": 2,\n  \"current_skills\": [\"HTML\", \"CSS\"],\n  \"role\": \"Frontend Developer\",\n  \"experience\": 0.5\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": [\"JavaScript\", \"Responsive Web Design\"],\n  \"reasons\": [\n    \"JavaScript is essential for adding interactivity and dynamic functionality to websites.  It's a foundational skill for any frontend developer.\",\n    \"Responsive web design ensures your websites adapt seamlessly to different screen sizes and devices, a critical skill for modern web development.\"\n  ]\n}\n```\n",
      ],
    },
  ]
)

    skills_str = ", ".join(skill.skills)
    chat_session = model.start_chat(history=[])

    prompt = f"""
Number of new Required Skills: {skill.number}
Current Skills: {', '.join(skill.skills)}

Do NOT recommend skills that are variations or extensions of the existing skills.
Focus on NEW areas of expertise that align with the user's role and experience.

Role: {skill.role}
Experience: {skill.experience}
"""


    try:
        response = chat_session.send_message(prompt)

        # Debugging: Print API response
        print(f"Raw API Response: {response.text}")

        if not response.text.strip():
            raise HTTPException(status_code=500, detail="Empty response from Gemini API.")

        # Remove triple backticks and any "json" tag
        cleaned_response = re.sub(r"```json|```", "", response.text).strip()

        # Parse JSON
        recommendations = json.loads(cleaned_response)
        return recommendations

    except json.JSONDecodeError as e:
        raise HTTPException(status_code=500, detail=f"Failed to parse response: {str(e)}")

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Gemini API request failed: {str(e)}")

