from src.database import get_db_connection

def fetch_employees_with_skills(required_skills):
    """Fetch employees who have at least one of the required skills using partial matching."""
    connection = get_db_connection()
    cursor = connection.cursor()

    query = """
    SELECT u.user_id, u.full_name, u.project_status, s.core_skills, s.proficiency_level 
    FROM users u
    JOIN employee_skills s ON u.user_id = s.employee_id
    WHERE u.project_status = 'available'
    AND (""" + " OR ".join([f"s.core_skills ILIKE %s" for _ in required_skills]) + ");"

    cursor.execute(query, tuple(f"%{skill}%" for skill in required_skills))
    employees = cursor.fetchall()

    cursor.close()
    connection.close()

    print("Fetched Employees:", employees)
    return employees
