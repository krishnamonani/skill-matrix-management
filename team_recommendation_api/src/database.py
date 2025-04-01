import psycopg2
from psycopg2.extras import DictCursor
from fastapi import HTTPException
from src.config import DB_CONFIG

def get_db_connection():
    """Establish database connection."""
    try:
        return psycopg2.connect(**DB_CONFIG, cursor_factory=DictCursor)
    except Exception as e:
        print("Database Connection Error:", e)
        raise HTTPException(status_code=500, detail="Database connection failed.")
