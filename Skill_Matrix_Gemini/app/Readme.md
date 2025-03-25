# FastAPI Skill Recommendation API

## Overview
This project is a FastAPI-based Skill Recommendation API that uses the Gemini AI model to generate skill suggestions based on user input.

## Requirements

Ensure you have the following installed before running the project:

- Python 3.8+
- FastAPI
- Uvicorn
- Pydantic
- Python-dotenv
- Google Generative AI SDK

## Installation

Follow these steps to set up the project:

### 1. Create a virtual environment
```sh
python -m venv venv
```

### 2. Activate the virtual environment
- On Windows:
  ```sh
  venv\Scripts\activate
  ```
- On macOS/Linux:
  ```sh
  source venv/bin/activate
  ```

### 3. Install dependencies
```sh
pip install -r requirements.txt
```

## Running the API

### 1. Set up environment variables
Create a `.env` file and add your Gemini API key:
```sh
GEMINI_API_KEY=your_api_key_here
```

### 2. Start the FastAPI server
```sh
uvicorn main:app --reload
```

### 3. Access API Documentation
- **Swagger UI**: [http://127.0.0.1:8000/docs](http://127.0.0.1:8000/docs)
- **ReDoc UI**: [http://127.0.0.1:8000/redoc](http://127.0.0.1:8000/redoc)

## API Usage

### Endpoint: `/recommend-skills`
**Method**: `POST`

#### Request Body:
```json
{
  "role": "Software Engineer",
  "n": 5,
  "current_skills": ["Python", "FastAPI"]
}
```

#### Response Example:
```json
{
  "recommended_skills": ["Docker", "Kubernetes", "GraphQL", "Microservices", "CI/CD"]
}
```

## Notes
- Modify the `.env` file to include your API key.
- Ensure all dependencies are installed before running the project.
- The API filters irrelevant responses from Gemini AI and returns only skill names.

