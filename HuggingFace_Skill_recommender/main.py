from fastapi import FastAPI
from pydantic import BaseModel
from transformers import pipeline

app = FastAPI(
    title="Skill Recommender API",
    description="Zero-shot skill recommendation using Hugging Face 🤗",
    version="1.0.0"
)

# Load zero-shot classifier (PyTorch backend)
classifier = pipeline(
    "zero-shot-classification",
    model="facebook/bart-large-mnli",
    framework="pt"
)

# Candidate skill labels (you can customize these)
candidate_labels = [
    "Data Analysis", "Data Science", "Machine Learning", "Deep Learning",
    "Web Development", "DevOps", "Project Management", "Excel Reporting",
    "Python Programming", "SQL", "Frontend Development", "Backend Development",
    "Cloud Computing", "Database Management", "Business Intelligence",
    "Cybersecurity", "Software Testing"
]

# Request model
class ProfileInput(BaseModel):
    profile_text: str

# Response model
class SkillScore(BaseModel):
    label: str
    confidence: float

@app.post("/recommend", response_model=list[SkillScore])
async def recommend_skills(input_data: ProfileInput):
    result = classifier(
        input_data.profile_text,
        candidate_labels,
        multi_label=True
    )
    # Sort and format output
    sorted_results = sorted(
        zip(result['labels'], result['scores']),
        key=lambda x: x[1],
        reverse=True
    )
    return [{"label": label, "confidence": round(score, 4)} for label, score in sorted_results]
