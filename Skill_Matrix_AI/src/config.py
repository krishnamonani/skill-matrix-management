import os
from dotenv import load_dotenv

# Load environment variables
load_dotenv()

# API Key
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")
GOOGLE_API_KEY = os.getenv("GOOGLE_API_KEY")

