import json
import os
import google.generativeai as genai
from database import get_db_connection
from config import GEMINI_API_KEY


genai.configure(api_key="AIzaSyCz75Z8HasQLzOhweCwe1y2TXPhrTgRDLA")

# Create the model
generation_config = {
  "temperature": 0.3,
  "top_p": 0.95,
  "top_k": 40,
  "max_output_tokens": 8192,
  "response_mime_type": "text/plain",
}

model = genai.GenerativeModel(
  model_name="gemini-1.5-flash",
  generation_config=generation_config,
  system_instruction="Input Format:\n\nProject Description: A short summary of the project, including objectives and key requirements.\n\nRequired Skills: A list of skills necessary for the project.\n\nEmployee Database: A structured dataset containing employee information, including their skills, experience, and availability.\n\nInstructions:\n\nIdentify the best-fit employees based on their skills and expertise.\n\nEnsure a balanced team with complementary skills to cover all project requirements.\n\nPrioritize employees who have relevant experience in similar projects.\n\nConsider availability to avoid assigning overloaded employees.\n\nEncourage diversity in expertise levels (mix of senior and junior employees for optimal team structure).\n\nOutput Format:\nA dictionary with key-value pairs:\n\njson\nCopy\nEdit\n{\n  \"team\": [\n    {\"name\": \"Employee1\", \"role\": \"ML Engineer\", \"skills\": [\"Python\", \"Deep Learning\"], \"experience\": \"5 years\"},\n    {\"name\": \"Employee2\", \"role\": \"Frontend Developer\", \"skills\": [\"React\", \"UI/UX\"], \"experience\": \"3 years\"},\n    {\"name\": \"Employee3\", \"role\": \"Data Engineer\", \"skills\": [\"SQL\", \"Big Data\"], \"experience\": \"4 years\"}\n  ],\n  \"reason\": \"The recommended team consists of members with diverse and complementary skills, ensuring the project’s success.\n  Employee1 is an ML Engineer with expertise in Deep Learning, crucial for AI model development.\n  Employee2 brings Frontend development skills to create a user-friendly interface.\n  Employee3 provides strong data engineering capabilities to handle large datasets efficiently.\"\n}",
)

chat_session = model.start_chat(
  history=[
    {
      "role": "user",
      "parts": [
        "{\n  \"project_description\": \"Develop an AI-powered customer support chatbot that can handle user queries efficiently using NLP and deep learning techniques.\",\n  \"required_skills\": [\"Natural Language Processing\", \"Deep Learning\", \"Frontend Development\", \"Cloud Deployment\", \"Database Management\"],\n  \"employee_database\": [\n    {\"name\": \"Alice\", \"role\": \"ML Engineer\", \"skills\": [\"Python\", \"Deep Learning\", \"NLP\"], \"experience\": \"5 years\", \"availability\": \"Yes\"},\n    {\"name\": \"Bob\", \"role\": \"Frontend Developer\", \"skills\": [\"React\", \"UI/UX\", \"JavaScript\"], \"experience\": \"3 years\", \"availability\": \"Yes\"},\n    {\"name\": \"Charlie\", \"role\": \"Cloud Engineer\", \"skills\": [\"AWS\", \"Cloud Deployment\", \"Kubernetes\"], \"experience\": \"4 years\", \"availability\": \"No\"},\n    {\"name\": \"David\", \"role\": \"Data Engineer\", \"skills\": [\"SQL\", \"Database Management\", \"Big Data\"], \"experience\": \"6 years\", \"availability\": \"Yes\"}\n  ]\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"team\": [\n    {\n      \"name\": \"Alice\",\n      \"role\": \"ML Engineer\",\n      \"skills\": [\"Python\", \"Deep Learning\", \"NLP\"],\n      \"experience\": \"5 years\"\n    },\n    {\n      \"name\": \"Bob\",\n      \"role\": \"Frontend Developer\",\n      \"skills\": [\"React\", \"UI/UX\", \"JavaScript\"],\n      \"experience\": \"3 years\"\n    },\n    {\n      \"name\": \"David\",\n      \"role\": \"Data Engineer\",\n      \"skills\": [\"SQL\", \"Database Management\", \"Big Data\"],\n      \"experience\": \"6 years\"\n    }\n  ],\n  \"reason\": \"This team balances senior and junior experience while covering the essential skills. Alice's expertise in Deep Learning and NLP is crucial for the chatbot's AI core. Bob will handle the frontend development for a user-friendly interface. David's database management skills are essential for data handling.  While a dedicated Cloud Engineer (Charlie) is unavailable, aspects of cloud deployment can be addressed by Alice and/or David, or outsourced if necessary.  The team's combined skills provide a solid foundation for the project.\"\n}\n```\n",
      ],
    },
  ]
)

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

employees = get_matching_employees(["Python", "Deep Learning", "NLP"], 3, 20)

def generate_team_recommendation(request, response):

    prompt  =f"""
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
        """

    response = chat_session.send_message(prompt)

    print(response.text)
    return response.text

