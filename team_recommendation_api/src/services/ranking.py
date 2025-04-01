def rank_employees(employees, required_skills):
    """Ranks employees based on skill match and proficiency level."""
    employee_scores = {}
    
    for emp in employees:
        user_id = emp["user_id"]
        if user_id not in employee_scores:
            employee_scores[user_id] = {
                "name": emp["full_name"],
                "status": emp["project_status"],
                "matched_skills": [],
                "proficiency_scores": []
            }
        
        employee_scores[user_id]["matched_skills"].append(emp["core_skills"])
        employee_scores[user_id]["proficiency_scores"].append(emp["proficiency_level"])

    ranked_team = []
    for user_id, data in employee_scores.items():
        skill_match_score = len(data["matched_skills"]) / len(required_skills)
        avg_proficiency = sum(data["proficiency_scores"]) / len(data["proficiency_scores"])
        final_score = (skill_match_score * 0.7) + (avg_proficiency * 0.3)

        ranked_team.append({
            "user_id": user_id,
            "name": data["name"],
            "matched_skills": data["matched_skills"],
            "average_proficiency": round(avg_proficiency, 2),
            "final_score": round(final_score, 2)
        })

    ranked_team.sort(key=lambda x: x["final_score"], reverse=True)
    return ranked_team
