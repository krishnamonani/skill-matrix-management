import os
from dotenv import load_dotenv

# Load environment variables
load_dotenv()

# API Key
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")
print(f"GEMINI_API_KEY: {GEMINI_API_KEY}")
