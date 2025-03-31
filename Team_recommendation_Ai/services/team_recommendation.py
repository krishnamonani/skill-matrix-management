import json
import google.generativeai as genai
from database import get_db_connection
from config import GEMINI_API_KEY

genai.configure(api_key=GEMINI_API_KEY)

def get_matching_employees(required_skills, min_experience, availability_hours):
    conn = get_db_connection()
    cur = conn.cursor()
    query = """
        SELECT e.employee_id, e.name, e.experience_years, e.department
        FROM employees e
        JOIN employee_skills es ON e.employee_id = es.employee_id
        JOIN skills s ON es.skill_id = s.skill_id
        WHERE e.experience_years >= %s AND e.availability_hours >= %s
        AND s.skill_name IN %s
        ORDER BY e.experience_years DESC;
    """
    skill_names = tuple(required_skills)
    cur.execute(query, (min_experience, availability_hours, skill_names))
    employees = cur.fetchall()
    conn.close()
    return employees

def generate_team_recommendation(request, employees):
    prompt = f"""
    Given the following project requirements:
    - Project Name: {request.project_name}
    - Deadline: {request.deadline}
    - Required Skills: {json.dumps(request.required_skills)}
    - Team Size: {request.team_size}
    - Role Distribution: {json.dumps(request.role_distribution)}
    - Minimum Experience: {request.min_experience} years
    - Availability: {request.availability_hours} hours/week
    - Diversity Preferences: {json.dumps(request.diversity_preferences)}
    Available Employees:
    {json.dumps(employees)}
    Suggest the best possible team for this project.
    """
    print(dir(genai))
    response = genai.generate(model="gemini-1.5-flash", prompt=prompt)
    return response.text
