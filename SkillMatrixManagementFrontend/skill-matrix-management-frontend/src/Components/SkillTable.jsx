import React, { useState } from "react";
import "./SkillTable.css"; // Add styling
const SkillTable = () => {
  const [skills, setSkills] = useState([
    { id: 1, name: "Skill Name 1" },
    { id: 2, name: "Skill Name 2" },
    { id: 3, name: "Skill Name 3" },
    { id: 4, name: "Skill Name 4" },
  ]);
  const deleteSkill = (id) => {
    setSkills(skills.filter((skill) => skill.id !== id));
  };
  return (
    <div className="skill-table">
      <h2>Skill in Role:</h2>
      <button className="recommend-btn">Recommend Skill</button>
      <button className="add-btn">Add Skill</button>
      <table>
        <thead>
          <tr>
            <th>Skill Name</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {skills.map((skill) => (
            <tr key={skill.id}>
              <td>{skill.name}</td>
              <td>
                <button className="edit-btn">Edit</button>
                <button className="delete-btn" onClick={() => deleteSkill(skill.id)}>:wastebasket:</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
export default SkillTable;