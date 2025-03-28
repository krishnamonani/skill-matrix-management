import React, { useState } from "react";
import Button from "./Button";

const SkillTable = () => {
  const [skills, setSkills] = useState(["Python", "Javascript", "React"]);
  const [newSkill, setNewSkill] = useState("");

  const addSkill = () => {
    if (newSkill.trim() !== "") {
      setSkills([...skills, newSkill]);
      setNewSkill("");
    }
  };

  const deleteSkill = (index) => {
    setSkills(skills.filter((_, i) => i !== index));
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow-md w-full max-w-3x mx-auto">
      {/* Input & Buttons */}
      <div className="flex flex-wrap gap-4 justify-between items-center mb-4">
        <input
          type="text"
          placeholder="Enter new skill"
          value={newSkill}
          onChange={(e) => setNewSkill(e.target.value)}
          className="border p-2 rounded-lg w-full max-w-md focus:ring-2 focus:ring-blue-400 outline-none"
        />
       
        <Button onClick={addSkill} variant="primary">Add Skill</Button>
        <Button variant="primary">Skill Recommend</Button>
      </div>

      {/* Table */}
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr className="bg-gray-100">
            <th className="p-3 border text-left">Skill Name</th>
            <th className="p-3 border text-left">Actions</th>
          </tr>
        </thead>
        <tbody>
          {skills.map((skill, index) => (
            <tr key={index} className="border">
              <td className="p-3 border">{skill}</td>
              <td className="p-3 border">
                <button
                  onClick={() => deleteSkill(index)}
                  className="text-red-500 hover:text-red-700 transition-transform transform hover:scale-110"
                >
                  🗑️
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SkillTable;
