
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
Exclude employees who are Busy.

Each employee also has:
- AssignibilityPercentage (how much they are assigned),
- BillablePercentage (how much is billable),
- AvailabilityPercentage = 100 - BillablePercentage,
- ProjectStatus is auto-calculated:
  * 100% available -> "AVAILABLE"
  * 0% available -> "BUSY"
  * partial availability -> "PARTIALLY_AVAILABLE"

Use these values to recommend the best team. Prefer higher availability.

Output only valid, working Team suggestions in JSON format wrapped inside an object with key 'Team'. 
Also extract the required skills from the project description and include them in a key called 'RequiredSkills'.
'''

def combine_skills_with_proficiencies(skills: list, profs: list) -> dict:
    return {skills[i]: profs[i] if i < len(profs) else "UNKNOWN" for i in range(len(skills))}

def calculate_availability_and_status(emp):
    billable = emp.get("BillablePercentage", 0)
    availability = 100 - billable
    emp["AvailabilityPercentage"] = availability

    if availability == 100:
        emp["ProjectStatus"] = "AVAILABLE"
    elif availability == 0:
        emp["ProjectStatus"] = "BUSY"
    else:
        emp["ProjectStatus"] = "PARTIALLY_AVAILABLE"

def recommend_team(project_description: str, employee_data: list):
    try:
        employee_data_dicts = [emp.dict() for emp in employee_data]

        for emp in employee_data_dicts:
            emp["Name"] = f"{emp.get('FirstName', '').strip().title()} {emp.get('LastName', '').strip().title()}"
            emp["skillProfile"] = combine_skills_with_proficiencies(
                emp.get("Skills", []),
                emp.get("Proficiencies", [])
            )
            calculate_availability_and_status(emp)

        irrelevant_keywords = [
            "data entry", "recruitment", "human resource", "excel sheet", 
            "admin task", "timesheet", "resume screening", "attendance", 
            "payroll", "pdf extraction", "meeting scheduler", "interview coordination"
        ]
        if any(keyword in project_description.lower() for keyword in irrelevant_keywords):
            return {
                "RequiredSkills": [],
                "Team": []
            }

        prompt = f"""

System Instruction:
{system_instruction}

Project Description:
{project_description}

Employee Data (with skill proficiencies and availability info):
{json.dumps(employee_data_dicts, indent=2)}

Instructions:
1. **First**, determine if the project description is **valid and technical**.
   - A valid description must **logically make sense**, involve **software development tasks**, and **clearly describe technical goals or problems**.
   - If the description is **unclear, unrealistic, humorous, vague, or non-technical** (e.g., making maggie with HTML, office parties, resume processing), then consider it invalid.

2. If the project description is INVALID:
   - Return: 
     {{
       "RequiredSkills": [],
       "Team": []
     }}

3. If the project description is VALID:
   - Extract relevant technical skills ONLY under the key `"RequiredSkills"`.

   - Recommend a team under key `"Team"`:
     - Match employee skills to RequiredSkills.
     - Only choose employees with `"ProjectStatus": "AVAILABLE"` or "PARTIALLY_AVAILABLE".
     - Add justification showing skill alignment and availability.
     - Include employee `"Id"`, `"Name"`, `"Role"`, `"AvailabilityPercentage"`, `"ProjectStatus"`, and `"Justification"`.

4. Format the output STRICTLY as:
{{
  "RequiredSkills": ["Python", "React", "Docker", "AWS"],
  "Team": [
    {{
      "Id": "...",
      "Name": "...",
      "Role": "...",
      "AvailabilityPercentage": 50,
      "ProjectStatus": "PARTIALLY_AVAILABLE",
      "Justification": "..."
    }}
  ]
}}

Only return valid technical responses. No markdown, no explanations. Ensure JSON is valid.
"""

        chat_session = model.start_chat(history=[])
        response = chat_session.send_message(prompt)
        cleaned_response = re.sub(r"```json|```", "", response.text.strip())
        parsed_response = json.loads(cleaned_response)

        required_skills = parsed_response.get("RequiredSkills", [])
        team_data = parsed_response.get("Team", [])

        return {
            "RequiredSkills": required_skills,
            "Team": team_data
        }

    except Exception:
        return {
            "RequiredSkills": [],
            "Team": []
        }
