1. Functional Requirements
Skill Recommendation API

Accepts user profile descriptions as input (e.g., resume summary, LinkedIn bio).

Uses a zero-shot classification model (facebook/bart-large-mnli) to predict relevant skills.

Returns skills with confidence scores in descending order.

 Endpoints

POST /recommend: Takes a profile_text and returns ranked skill recommendations.

2. Non-Functional Requirements
Performance: Optimize response time (consider caching if needed).

Scalability: Deployable as a FastAPI microservice.

Security: Use input validation (Pydantic) to prevent malicious payloads.

Logging & Monitoring: Log requests and responses for debugging.

3. Tech Stack
Backend: FastAPI

ML Model: Hugging Face facebook/bart-large-mnli (Zero-shot classification)

Testing: Pytest for API testing

API Docs: Automatic with FastAPI (Swagger UI)

4. Enhancements & Future Scope
 Expand Skill Labels: Use a dynamic skill database instead of a fixed list.
 Multi-model Approach: Use fine-tuned models or embeddings (e.g., Sentence Transformers) for better accuracy.
 Database Integration: Store past recommendations for analytics.
 Frontend Dashboard: Build a simple UI to interact with the API.