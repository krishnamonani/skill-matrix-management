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

        # Step 1: Use Gemini to validate the project description
        validation_prompt = f"""
You are a strict validator for software project descriptions.

Task:
Determine whether the text below is a valid technical software project description.

Respond ONLY with:
- "Yes" (if the project is clearly about building a software system or app)
- "No" (if the project is too vague, non-technical, or not software-related)

Do not add any explanation.

Examples:
- "We are building a web application using React and Node.js." → Yes
- "An AI-based mentor-mentee matching system using NLP." → Yes
- "Developing a mobile app for e-commerce using Flutter and Firebase." → Yes
- "Alice Smith engineering" → No
- "Project for testing only" → No
- "N/A" → No
- "Test" → No

Now answer this:

Project Description:
{project_description}
"""

        validation_response = model.generate_content(validation_prompt)
        response_text = validation_response.text.strip().lower()
        response_text = re.sub(r'[^\w]', '', response_text)  

        print("Gemini validation response:", response_text)

        if response_text != "yes":
            raise HTTPException(
                status_code=400,
                detail="The project description is not valid or technical enough. Please provide a proper software project requirement."
            )

        # Step 2: Proceed with recommendation prompt
        prompt = f"""
System Instruction: 
{system_instruction}

Project Description:
{project_description}

Employee Data (with skill proficiencies):
{json.dumps(employee_data_dicts, indent=2)}

Instructions:
1. Analyze the project description carefully and extract **only technical skills** required for this project under a key called "RequiredSkills".
   - Only include programming languages, frameworks, libraries, databases, cloud platforms, DevOps tools, APIs, and other software-related technologies.
   - Do NOT include soft skills or general attributes like "communication", "teamwork", "problem solving", etc.
   - Ensure all skill names are standardized and technology-specific (e.g., "JavaScript" not "JS", "PostgreSQL" not "SQL database").

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

    except HTTPException as http_err:
        raise http_err  # Allow already-raised HTTPExceptions to propagate
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Error while recommending Team: {str(e)}")
