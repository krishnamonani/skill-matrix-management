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
system_instruction = '''You are an expert project team recommender. Based on the given project description and employee data, 
    recommend the best-fit team. Prioritize employees based on skill match, experience, availability, and budget. 
    If the project has a high budget, consider senior roles (e.g., SE2, Tech Lead). If the budget is low, consider SE1-level employees. 
    Exclude employees who are BUSY. Output only valid, working team suggestions in JSON format wrapped inside an object with key 'Team'.
'''

def combine_skills_with_proficiencies(skills: list, profs: list) -> dict:
    return {skills[i]: profs[i] if i < len(profs) else "UNKNOWN" for i in range(len(skills))}

def recommend_team(project_description: str, employee_data: list):
    try:
        employee_data_dicts = [emp.dict() for emp in employee_data]

        # Add skillProfile to each employee
        for emp in employee_data_dicts:
            emp["skillProfile"] = combine_skills_with_proficiencies(
                emp.get("skills", []),
                emp.get("proficiencies", [])
            )

        prompt = f"""

        System Instruction: 
        {system_instruction}

Project Description:
{project_description}

Employee Data (with skill proficiencies):
{json.dumps(employee_data_dicts, indent=2)}

Instructions:
- Analyze the project description to extract required skills.
- Match employees based on skillProfile and availability.
- Use experience and designation to assign roles.
- Ignore employees with projectStatus = "Busy".
- Return a recommended Team with justification for each member.
- Wrap the response in an object with key 'Team'

Example Format:
{{
  "Team": [
    {{
      "Id": "E101",
      "Name": "Alice Johnson",
      "Role": "Backend Developer",
      "ProjectStatus": "Available",
      "Justification": "Alice has strong proficiency in Python and Django (both rated as 'Expert'), 4 years of experience, and is currently available. She matches key backend requirements mentioned in the project."
    }},
    {{
      "Id": "E202",
      "Name": "Bob Smith",
      "Role": "Frontend Developer",
      "ProjectStatus": "Available",
      "Justification": "Bob has 3 years of experience in React and TypeScript, which aligns well with the UI-focused needs of the project. He is also available and within the mid-level budget range."
    }}
  ]
}}

Please follow the above format strictly and return only valid JSON.
"""

        chat_session = model.start_chat(history=[])

        response = chat_session.send_message(prompt)

        print("Raw Gemini Response:", response.text)

        cleaned_response = re.sub(r"```json|```", "", response.text.strip())
        parsed_response = json.loads(cleaned_response)

        # If response is a list, wrap it in a dict with key 'Team'
        if isinstance(parsed_response, list):
            team_data = {"Team": parsed_response}
        else:
            team_data = parsed_response

        return team_data

    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Error while recommending Team: {str(e)}")
