import google.generativeai as genai
import os
import json
import re
from dotenv import load_dotenv
from fastapi import HTTPException
from src.config import GEMINI_API_KEY

load_dotenv()
genai.configure(api_key=GEMINI_API_KEY)

generation_config = {
    "temperature": 0.7,
    "top_p": 0.95,
    "top_k": 40,
}

model = genai.GenerativeModel(
    model_name="gemini-1.5-flash",
    generation_config=generation_config
)

system_instruction = '''You are an expert project Team recommender. Based on the given project description and employee data, 
recommend the best-fit Team. Prioritize employees based on skill match, experience, availability, and budget. 
If the project has a high budget, consider senior roles (e.g., SE2, Tech Lead). If the budget is low, consider SE1-level employees. 
Exclude employees who are BUSY. Output only valid, working Team suggestions in JSON format wrapped inside an object with key 'Team'. 
Also extract the required skills from the project description and include them in a key called 'RequiredSkills'.
'''

def combine_skills_with_proficiencies(skills: list, profs: list) -> dict:
    return {skills[i]: profs[i] if i < len(profs) else "UNKNOWN" for i in range(len(skills))}

def recommend_team(project_description: str, employee_data: list):
    try:
        employee_data_dicts = [emp.dict() for emp in employee_data]

        for emp in employee_data_dicts:
            emp["skillProfile"] = combine_skills_with_proficiencies(
                emp.get("Skills", []),
                emp.get("Proficiencies", [])
            )

        prompt = f"""

System Instruction: 
{system_instruction}

Project Description:
{project_description}

Employee Data (with skill proficiencies):
{json.dumps(employee_data_dicts, indent=2)}

Instructions:
1. Analyze the project description carefully and extract **all relevant technical and soft skills** required for this project under a key called "RequiredSkills".
   - These should include **programming languages, tools, frameworks, cloud platforms, databases, libraries, DevOps tools, testing tools, and domain-specific knowledge**.
   - Consider both **explicitly mentioned** and **implicitly needed** skills for the project.
   - If integration, architecture, or team coordination is implied, include skills like "API Integration", "System Design", "Agile", or "Team Collaboration".
   - Ensure all skills are standardized (e.g., use "JavaScript" not "JS").

2. Then, recommend a Team of best-fit employees under a key called "Team":
   - Match employees based on skillProfile and availability.
   - Use experience and designation to assign roles.
   - Ignore employees with ProjectStatus = "Busy".
   - Provide a justification for each Team member's selection.

Format the response as valid JSON with the following structure:
{{
  "RequiredSkills": ["Python", "React", "Docker", "AWS"],
  "Team": [
    {{
      "Id": "E101",
      "Name": "Alice Johnson",
      "Role": "Backend Developer",
      "ProjectStatus": "Available",
      "Justification": "Alice has strong proficiency in Python and Django..."
    }},
    {{
      "Id": "E202",
      "Name": "Bob Smith",
      "Role": "Frontend Developer",
      "ProjectStatus": "Available",
      "Justification": "Bob has experience in React and TypeScript..."
    }}
  ]
}}

Please follow the format strictly and return only valid JSON.
"""


        chat_session = model.start_chat(history=[])
        response = chat_session.send_message(prompt)

        print("Raw Gemini Response:", response.text)

        cleaned_response = re.sub(r"```json|```", "", response.text.strip())
        parsed_response = json.loads(cleaned_response)

        required_skills = parsed_response.get("RequiredSkills", [])
        team_data = parsed_response.get("Team", [])

        return {
            "RequiredSkills": required_skills,
            "Team": team_data
        }

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Error while recommending Team: {str(e)}")
