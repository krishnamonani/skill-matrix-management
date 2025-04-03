import os
import google.generativeai as genai
from fastapi import HTTPException
from typing import List
from .models import Skill_req


# Configure Gemini API
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")

if not GEMINI_API_KEY:
    raise RuntimeError("GEMINI_API_KEY is missing! Set it in the environment variables.")

genai.configure(api_key=GEMINI_API_KEY)


def generate_skill_recommendation(skill: Skill_req):
    """Generates skill recommendations using Gemini AI."""
    
   
    genai.configure(api_key=GEMINI_API_KEY)

    generation_config = {
    "temperature": 0.2,
    }

    model = genai.GenerativeModel(
    model_name="gemini-1.5-flash",
    generation_config=generation_config,
    system_instruction="Input Format:\n\nNumber of new Required Skills:\nCurrent Skills: \nRole: \n\nSuggest the top skills as requested by user also consider current role of the user. The user should learn to enhance their expertise.  \nThe employee already has proficiency in his/her current skills.  \nExclude these from your recommendations.  \n\nInstructions:  \n- Focus on technical and industry-relevant skills.  \n- Prioritize skills that are in high demand for this role.  \n- Output should a dictionary with key value pairs with key 'skills' (having list of skills) and 'reason' (having a short explanation of why the above skills are relevant.)\n\n\nExample Usage:\n\nInput:\nNumber of new Required Skills: 3\nCurrent Skills: Python, Pandas, Machine Learning\nRole: AI/ML Developer\n\nOutput:\n{\"skills\":\"['Deep Learning','GenAI','Cloud Computing']\",\n \"reason\":\"These skills are crucial for an AI/ML Developer to advance in their career. \n  Deep Learning is essential for working with neural networks and complex AI models. \n  GenAI (Generative AI) is a rapidly growing field, enabling developers to build advanced AI applications like chatbots and content generation models. \n  Cloud Computing is important for deploying, scaling, and managing ML models efficiently on platforms like AWS, GCP, or Azure.\"}",
    )

    chat_session = model.start_chat(
    history=[
        {
        "role": "user",
        "parts": [
            "Number of new Required Skills: 4\nCurrent Skills: HTML, CSS, JS\nRole: Front-End Developer",
        ],
        },
        {
        "role": "model",
        "parts": [
            "{\n  \"skills\": [\"React\", \"Angular or Vue.js\", \"TypeScript\", \"Web Accessibility\"],\n  \"reason\": \"These skills are highly sought after for Front-End Developers. React, Angular, and Vue.js are popular JavaScript frameworks that enable efficient and scalable web application development.  TypeScript adds static typing to JavaScript, improving code maintainability and reducing errors in large projects. Web Accessibility ensures your applications are usable by people with disabilities, a crucial aspect of inclusive design and increasingly important for compliance.\"\n}",
        ],
        },
        {
        "role": "user",
        "parts": [
            "Number of new Required Skills: 3\nCurrent Skills: Linux, Docker\nRole: Dev-Ops",
        ],
        },
        {
        "role": "model",
        "parts": [
            "{\n  \"skills\": [\"Kubernetes\", \"Terraform or CloudFormation\", \"CI/CD pipelines\"],\n  \"reason\": \"These skills are crucial for advancing in a DevOps role. Kubernetes is essential for container orchestration and management at scale.  Terraform or CloudFormation are Infrastructure-as-Code (IaC) tools that automate infrastructure provisioning and management, improving efficiency and consistency.  CI/CD (Continuous Integration/Continuous Delivery) pipelines automate the software release process, enabling faster and more reliable deployments.\"\n}",
        ],
        },
    ]
    )
    prompt=f"""
    Number of new Required Skills: {skill.number}\nCurrent Skills: {skill.skills}\nRole: {skill.role}"""
    response = chat_session.send_message(prompt)

    dict1 = (response.text)
    rec=eval(dict1[8:-5])

# Print the dictionary
    return rec
