# import os
# from dotenv import load_dotenv

# load_dotenv()

# GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")
import os
from dotenv import load_dotenv

# Load .env file
load_dotenv()

# API Key for Gemini
GEMINI_API_KEY = os.getenv("GEMINI_API_KEY")

if not GEMINI_API_KEY:
    raise RuntimeError("Missing GEMINI_API_KEY in .env")
