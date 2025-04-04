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
Processing Guidelines:  
- Recommend only new, high-value skills that align with the user's role, experience level, and career growth.  
- Do NOT suggest skills that are already in the 'Current Skills' list or closely related variations (e.g., if the user knows 'Machine Learning,' do NOT recommend 'Supervised Learning' separately).  
- Prioritize advanced, leadership, or specialized skills for users with 5+ years of experience.  
- If the user has 10+ years of experience**, focus on strategic, architectural, or cross-disciplinary skills rather than hands-on technical skills.  
- Avoid generic or introductory skills (e.g., do not recommend 'Python' to someone already skilled in AI/ML).  
- For industry-specific roles, recommend niche skills (e.g., 'AI in Finance' instead of general 'AI Ethics').  
- Ensure recommendations help enhance the user's expertise and career growth.  
- Strictly exclude any skills that are variations or direct extensions of the listed Current Skills (e.g., if the user knows JavaScript, do not suggest TypeScript unless a significant gap exists).
- Prioritize skills that expand the user's expertise rather than slightly modifying existing skills.
- Ensure each recommended skill is distinct from the listed ones and introduces a new area of knowledge or specialization.
- For junior-level users, suggest foundational and emerging skills.  
- For mid-level and senior professionals, suggest advanced, leadership-oriented, and specialized skills.  

Output Format:  
The system should return a JSON object with the following key-value pairs:  
- "skills": A dictionary where:  
  - Keys are the recommended skill names.  
  - Values are individual explanations of why each skill is relevant.  

 '''
        ),
    )

    chat_session = model.start_chat(
  history=[
    {
      "role": "user",
      "parts": [
        "Number of new Required Skills: 3  \nCurrent Skills: Python, Pandas, Machine Learning  \nRole: AI/ML Developer  \nExperience: 2 years  \n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": {\n    \"Deep Learning\": \"With 2 years of experience in AI/ML, building upon your foundation in Machine Learning by learning Deep Learning is a natural progression.  Deep learning is essential for advanced AI model development, encompassing neural networks and enabling you to tackle complex problems like image recognition, natural language processing, and more.\",\n    \"MLOps\": \"As an AI/ML developer, understanding MLOps (Machine Learning Operations) is critical for deploying and managing your models effectively in production. This involves streamlining the entire machine learning lifecycle, improving model reliability, and scaling your projects efficiently.\",\n    \"TensorFlow/PyTorch\": \"While you know Python, mastering a deep learning framework like TensorFlow or PyTorch is crucial. These frameworks provide tools and resources to build, train, and deploy complex deep learning models efficiently, expanding your capabilities significantly.\"\n  }\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "Number of new Required Skills: 3  \nCurrent Skills: Python, Pandas, Machine Learning , Deep Learning,YOLO,ML,CVIP,NLP\nRole: AI/ML Developer  \nExperience: 2 years  ",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": {\n    \"MLOps\": \"With your existing strong foundation in AI/ML, including Deep Learning, YOLO, and NLP, focusing on MLOps (Machine Learning Operations) is the next logical step.  MLOps will allow you to effectively deploy, monitor, and maintain your models in production environments, a crucial skill for any AI/ML developer.\",\n    \"Cloud Computing (AWS/Azure/GCP)\": \"To scale your AI/ML projects effectively, proficiency in at least one major cloud platform (AWS, Azure, or GCP) is essential.  These platforms offer scalable computing resources, storage solutions, and managed services specifically designed for machine learning workloads, allowing you to deploy and manage your models more efficiently.\",\n    \"Software Engineering Principles\": \"Strengthening your software engineering fundamentals will improve the quality, maintainability, and scalability of your AI/ML projects. This includes best practices in version control (Git), software design patterns, testing methodologies, and writing clean, well-documented code, significantly increasing your value as an AI/ML Developer.\"\n  }\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "Number of new Required Skills: 5\nCurrent Skills: Python, Pandas, Machine Learning , Deep Learning,YOLO,ML,CVIP,NLP, Software engineering\nRole: AI/ML Developer\nExperience: 2 years",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": {\n    \"MLOps\": \"Given your strong background, including software engineering, the next crucial step is mastering MLOps. This will allow you to effectively deploy, monitor, and maintain your models in production, a highly sought-after skill for AI/ML developers.\",\n    \"Cloud Computing (AWS/Azure/GCP)\": \"Proficiency in a major cloud platform (AWS, Azure, or GCP) is essential for scaling your AI/ML projects.  These platforms offer managed services and resources optimized for machine learning, crucial for deploying and managing your models efficiently.\",\n    \"Data Visualization (e.g., Tableau, Power BI)\": \"Effective communication of insights from your AI/ML models is key.  Learning data visualization tools will help you present your findings clearly and persuasively to stakeholders, a critical skill for career advancement.\",\n    \"Big Data Technologies (e.g., Spark, Hadoop)\": \"To handle increasingly large datasets common in AI/ML, familiarity with big data technologies is highly beneficial.  This will enable you to process and analyze massive amounts of data efficiently, expanding your project capabilities.\",\n    \"Deployment and Containerization (Docker, Kubernetes)\":  \"To streamline the deployment and scaling of your AI/ML models, learn containerization technologies like Docker and Kubernetes.  This allows for consistent and efficient deployment across different environments, making your models more robust and scalable.\"\n  }\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "Number of new Required Skills: 4  \nCurrent Skills: Java, Spring Boot, SQL, Git  \nRole: Backend Developer  \nExperience: 5 years  \n\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": {\n    \"Microservices Architecture\": \"With 5 years of experience, moving towards a microservices architecture is a natural progression. This allows for better scalability, maintainability, and independent deployment of your backend applications, enhancing your expertise and increasing your value.\",\n    \"Cloud Platforms (AWS, Azure, or GCP)\": \"Cloud adoption is now standard for backend development.  Familiarizing yourself with a major cloud provider's services (like AWS, Azure, or GCP) will open doors to more advanced and scalable solutions, enabling you to build and deploy more robust applications.\",\n    \"API Gateway and Security\": \"Securing and managing APIs is paramount.  Gaining experience with API gateways and various security protocols (OAuth 2.0, JWT) will improve the overall security and management of your backend systems, making your applications more resilient.\",\n    \"Containerization (Docker and Kubernetes)\": \"Containerization is becoming increasingly important for deploying and managing applications efficiently. Mastering Docker and Kubernetes allows for streamlined deployment, improved scalability, and easier management of your applications across different environments.\"\n  }\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "Number of new Required Skills: 3  \nCurrent Skills: Figma, Adobe XD, Wireframing, Prototyping, User Research, Design Thinking  \nRole: UI/UX Designer  \nExperience: 3 years  \n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": {\n    \"Motion Design\": \"Adding motion design skills to your existing UI/UX skillset will significantly elevate your designs, creating more engaging and intuitive user experiences. This is a highly sought-after skill in the current market.\",\n    \"Accessibility Design Principles\": \"Mastering accessibility design principles is crucial for creating inclusive and usable products for everyone.  Understanding WCAG guidelines and implementing them in your designs demonstrates a commitment to user-centered design and broadens your appeal to potential employers.\",\n    \"Interaction Design\": \"Focusing on interaction design will allow you to create more intuitive and engaging user flows.  By understanding how users interact with your designs, you can craft more seamless and enjoyable experiences, leading to higher user satisfaction and improved product adoption.\"\n  }\n}\n```\n",
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

