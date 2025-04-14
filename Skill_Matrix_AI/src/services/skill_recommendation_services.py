import os
import google.generativeai as genai
from fastapi import HTTPException
from typing import List
from src.schemas.skill_recommendation_schema import Skill_req
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
        
    }

    model = genai.GenerativeModel(
        model_name="gemini-1.5-flash",
        generation_config=generation_config,
    )
    system_instruction=''' You are a professional career and technical skill recommender.

The system will receive the following inputs:
1. Number of new Required Skills – Number of additional technical skills the user wants to learn.
2. Current Skills – A list of technical skills the user already has.
3. Role – The user's current job role.
4. Experience (in years) – The user's total years of experience.

Your task is to recommend ONLY technical, hands-on, advanced skills that align with the user's job role, experience level, and current skillset.

 DO NOT recommend:
- Soft skills (e.g., communication, time management)
- Cloud basics or DevOps tools (unless explicitly relevant to role)
- Skills already known or closely related/nested ones (e.g., TypeScript if user knows JavaScript)

 For Each Recommended Skill:
- Explain **why the user should learn it** in **second person** (“You should learn…”).
- Always write the reason from the **user’s perspective**: “You should learn this because…”
- Incorporate their **role** and **years of experience** naturally.
- Ensure each skill offers a **distinct technical capability**, not minor overlaps.
- Be precise, career-oriented, and avoid generic phrases.

 Output Format (JSON):
{
  "RecommendedSkills": [ "Skill1", "Skill2", "Skill3" ],
  "Reasons": [
    "You should learn Skill1 because...",
    "You should learn Skill2 because...",
    "You should learn Skill3 because..."
  ]
}
 '''
       

    chat_session = model.start_chat(
  history=[
    {
      "role": "user",
      "parts": [
        "{\n  \"num_skills\": 3,\n  \"current_skills\": [\"Python\", \"Git\", \"SQL\"],\n  \"role\": \"Data Scientist\",\n  \"experience\": 2\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"skills\": [\"Data Visualization with Tableau/Power BI\", \"Machine Learning Model Deployment (using Flask/Streamlit)\", \"Time Series Analysis with ARIMA/Prophet\"],\n  \"Reasons\": [\n    \"Data visualization is crucial for communicating insights from data analysis effectively to both technical and non-technical audiences.  Tableau and Power BI are industry-standard tools that offer powerful and intuitive interfaces for creating compelling visualizations.  This is a significant step up from basic plotting libraries in Python.\",\n    \"To increase the impact of your data science work, you need to deploy your models for real-world usage.  Learning to deploy models using frameworks like Flask (for web applications) or Streamlit (for interactive dashboards) will be highly valuable for transitioning your projects from prototypes to production-ready systems. This bridges the gap between analysis and implementation.\",\n    \"Time series data is prevalent across many industries. Mastering techniques like ARIMA and Prophet will allow you to analyze trends and make forecasts, expanding your skill set to a wide array of applications relevant to data science roles.  This builds upon your existing Python skills but introduces a dedicated area of specialized expertise.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 3,\n  \"current_skills\": [\"Python\", \"Scikit-learn\", \"Pandas\", \"NumPy\"],\n  \"role\": \"Softwear Engineer AIML\",\n  \"experience\": 4\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"TensorFlow/Keras\", \"MLOps principles and tools (e.g., MLflow, Kubeflow)\", \"Deep Learning for NLP (using Transformers)\"],\n  \"Reasons\": [\n    \"You should learn TensorFlow/Keras because, as a Software Engineer in AI/ML with 4 years of experience,  proficiency in these frameworks is essential for building and deploying complex, production-ready AI models.  This builds upon your existing Python and Scikit-learn foundation but allows you to tackle much larger and more sophisticated problems.\",\n    \"Since you're a Software Engineer in AI/ML, understanding MLOps principles and utilizing tools like MLflow or Kubeflow is crucial for streamlining the machine learning workflow, from model training to deployment and monitoring. This skill significantly increases your value by addressing the challenges of production-level machine learning.\",\n    \"Deep learning for NLP, particularly using Transformers, is a highly sought-after skill for AI/ML software engineers.  Familiarity with these architectures (like BERT, GPT) is increasingly important for developing state-of-the-art applications in natural language processing, expanding your capabilities within the broader field.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 3,\n  \"current_skills\": [\"Python\", \"Scikit-learn\", \"Pandas\", \"NumPy\"],\n  \"role\": \"Softwaer Engineer AIML 1\",\n  \"experience\": 4\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"TensorFlow/Keras\", \"Deployment of ML models (using Flask/Streamlit)\", \"Version control with Git (advanced branching strategies)\"],\n  \"Reasons\": [\n    \"You should learn TensorFlow/Keras because they are industry-standard deep learning frameworks that will allow you to build more complex and powerful AI models than you can with scikit-learn alone. This is a natural progression from your existing Python and machine learning skills.\",\n    \"As a Software Engineer in AI/ML, you'll need to deploy your models into real-world applications. Learning to deploy models using frameworks like Flask (for web applications) or Streamlit (for interactive dashboards) is crucial for bridging the gap between research and production.  This translates your modeling skills into tangible, deployable solutions.\",\n    \"While you mentioned Git in your skills, you should delve deeper into advanced branching strategies and collaborative workflows within Git.  This is essential for efficient and robust code management in a team setting, common in software engineering roles.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 3,\n  \"current_skills\": [\"HTML\", \"CSS\", \"JavaScript\", \"React\"],\n  \"role\": \"Frontend Developer\",\n  \"experience\": 2\n}\n\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Redux or Zustand\", \"Testing frameworks (Jest, Cypress)\", \"Next.js or similar framework\"],\n  \"Reasons\": [\n    \"You should learn Redux or Zustand because state management becomes critical as your React applications grow in complexity.  These libraries provide structured ways to manage application state, improving code organization and maintainability. This will be essential for larger frontend projects.\",\n    \"Testing is crucial for building robust and reliable web applications. Learning testing frameworks like Jest for unit testing and Cypress for end-to-end testing will significantly enhance your development workflow and the quality of your code. This is a valuable skill for any professional frontend developer.\",\n    \"Next.js (or similar frameworks like Gatsby or Remix) will allow you to build more sophisticated and performant React applications. These frameworks provide features like server-side rendering, routing, and API routes, expanding your capabilities beyond basic React component development. This is a significant step towards building complex, high-quality web applications.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 3,\n  \"current_skills\": [\"HTML\", \"CSS\", \"JavaScript\", \"React\"],\n  \"role\": \"Frontend Developer\",\n  \"experience\": 2\n}\n\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Redux Toolkit\", \"Testing with Jest and React Testing Library\", \"Next.js\"],\n  \"Reasons\": [\n    \"You should learn Redux Toolkit because it simplifies the process of managing application state in React, building upon your existing JavaScript and React skills.  It addresses common Redux complexities, making state management more efficient and maintainable in larger projects.\",\n    \"Testing is crucial for building robust and reliable applications.  Combining Jest with React Testing Library allows you to write clear, concise, and maintainable tests focused on user interaction, enhancing the overall quality of your React components. This directly improves your development process and the reliability of your code.\",\n    \"Next.js will significantly enhance your ability to build complex and performant React applications.  It provides features such as server-side rendering (SSR), static site generation (SSG), and API routes, making your applications faster, more scalable, and better suited for SEO. This is a key advancement for building production-ready frontend projects.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 2,\n  \"current_skills\": [\"Python\", \"TensorFlow\", \"NLP\", \"Keras\"],\n  \"role\": \"AI Specialist in Healthcare\",\n  \"experience\": 10\n}\n\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Federated Learning\", \"Explainable AI (XAI) techniques\"],\n  \"reasons\": [\n    \"Given your extensive experience as an AI Specialist in Healthcare, you should learn Federated Learning.  This cutting-edge technique allows you to train AI models on decentralized data sources while preserving patient privacy, a crucial aspect of healthcare applications. It will greatly expand your capabilities in handling sensitive medical data.\",\n    \"Explainable AI (XAI) is becoming increasingly important in healthcare to ensure the transparency and trustworthiness of AI-driven decisions.  Mastering XAI techniques will enable you to interpret and communicate the reasoning behind your AI models, building confidence and acceptance among clinicians and patients. This is a critical skill for responsible AI deployment in a sensitive domain like healthcare.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 5,\n  \"current_skills\": [\"Python\", \"TensorFlow\", \"NLP\", \"Keras\"],\n  \"role\": \"AI Specialist in Healthcare\",\n  \"experience\": 10\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Federated Learning\", \"Explainable AI (XAI) techniques\", \"Medical Image Analysis with Deep Learning\", \"Deployment of AI models in a HIPAA-compliant environment\", \"Healthcare Data Governance and Privacy Regulations\"],\n  \"reasons\": [\n    \"Given your extensive experience as an AI Specialist in Healthcare, you should learn Federated Learning. This cutting-edge technique allows you to train AI models on decentralized data sources while preserving patient privacy—a crucial aspect of healthcare applications.\",\n    \"Explainable AI (XAI) is increasingly important in healthcare to ensure the transparency and trustworthiness of AI-driven decisions. Mastering XAI techniques will enable you to interpret and communicate the reasoning behind your AI models, building confidence and acceptance among clinicians and patients.\",\n    \"Medical image analysis using deep learning is a rapidly growing field with immense potential in healthcare.  Expanding your expertise in this area will open doors to a wide range of applications, from disease diagnosis to treatment planning.\",\n    \"Deployment of AI models in a HIPAA-compliant environment is crucial for any AI Specialist in Healthcare.  Learning the necessary security and privacy protocols for deploying and maintaining AI models within healthcare systems is a crucial requirement.\",\n    \"A deep understanding of healthcare data governance and privacy regulations, such as HIPAA, is paramount for responsible AI development and deployment in the healthcare industry. This is essential for navigating the legal and ethical considerations of using patient data for AI applications.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"RecommendedSkills\": 2,\n  \"current_skills\": [\"Python\", \"TensorFlow\", \"NLP\", \"Keras\"],\n  \"role\": \"AI Specialist in Healthcare\",\n  \"experience\": 10\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Reinforcement Learning for Healthcare Applications\", \"Deployment of AI models in a production healthcare environment\"],\n  \"reasons\": [\n    \"You should learn Reinforcement Learning for Healthcare Applications because it's a powerful technique for optimizing complex decision-making processes in healthcare.  With your extensive background, you can leverage this to develop intelligent systems for personalized treatment plans, resource allocation, or robotic surgery assistance.\",\n    \"As an experienced AI specialist, mastering the deployment of AI models in a production healthcare environment is critical. This goes beyond simply deploying a model and involves considerations like scalability, security, integration with existing systems, and compliance with regulations like HIPAA.  It's a crucial step in bridging the gap between research and real-world impact.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"number_of_skills\": 3,\n  \"current_skills\": [\"SQL\", \"Excel\", \"Power BI\"],\n  \"role\": \"Data Analyst\",\n  \"experience\": 2\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Advanced SQL (window functions, CTEs, optimization)\", \"Data storytelling and visualization techniques\", \"Python for data analysis (Pandas, NumPy, data manipulation)\"],\n  \"reasons\": [\n    \"You should learn advanced SQL techniques like window functions and common table expressions (CTEs) to efficiently handle complex data manipulations and aggregations directly within your database.  This will significantly improve your query performance and allow you to tackle more challenging analytical tasks.  This builds upon your existing SQL foundation.\",\n    \"As a data analyst, effectively communicating your findings is crucial.  Learning data storytelling techniques, coupled with your Power BI skills, will enable you to present insights in a compelling and understandable manner to both technical and non-technical audiences. This directly improves the impact of your analysis.\",\n    \"Python with libraries like Pandas and NumPy will greatly expand your data analysis capabilities beyond Excel and Power BI.  You'll gain proficiency in data cleaning, transformation, and more advanced statistical analysis. This adds a powerful programming layer to your skill set, essential for more complex projects and career advancement.\"\n  ]\n}\n```\n",
      ],
    },
    {
      "role": "user",
      "parts": [
        "{\n  \"number_of_skills\": 3,\n  \"current_skills\": [\"Python\", \"TensorFlow\", \"Scikit-learn\"],\n  \"role\": \"AI/ML Engineer\",\n  \"experience\": 5\n}\n",
      ],
    },
    {
      "role": "model",
      "parts": [
        "```json\n{\n  \"RecommendedSkills\": [\"Deep Learning model optimization techniques\", \"Cloud-based ML platforms (AWS SageMaker, Google Vertex AI, Azure ML)\", \"MLOps practices and tools\"],\n  \"Reasons\": [\n    \"You should learn deep learning model optimization techniques because, with five years of experience, you're likely working on increasingly complex models.  Mastering optimization strategies like pruning, quantization, and knowledge distillation will allow you to build more efficient and performant models, which is crucial for production deployment and resource management.\",\n    \"Cloud-based ML platforms provide scalable and cost-effective infrastructure for training and deploying AI models.  Familiarity with AWS SageMaker, Google Vertex AI, or Azure ML will enable you to leverage their managed services and tools, significantly speeding up your development cycles and improving collaboration.\",\n    \"MLOps practices and tools are essential for managing the entire machine learning lifecycle, from model development to deployment and monitoring.  Learning MLOps will allow you to build robust, reliable, and scalable AI systems, a critical skill for senior AI/ML engineers.\"\n  ]\n}\n```\n",
      ],
    },
  ]
)

    skills_str = ", ".join(skill.skills)
    

    prompt = f"""
Number of new Required Skills: {skill.number}
Current Skills: {', '.join(skill.skills)}

Do NOT recommend skills that are variations or extensions of the existing skills.
Focus on NEW areas of expertise that align with the user's role and experience.

Role: {skill.role}
Experience: {skill.experience}
IMPORTANT:
- Write all Reasons in the second person (e.g., "You should learn...").
- Each reason must begin with "You should learn [Skill] because..."
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

