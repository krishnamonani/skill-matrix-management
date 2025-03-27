import React from "react";
import "../styles.css/Sidebar.css"; // Import styles
const Sidebar = () => {
  return (
    <div className="sidebar">
      <h2>Skill Matrix</h2>
      <ul>
        <li>Home</li>
        <li>Assessment</li>
        <li>Skills</li>
        <li>Project</li>
      </ul>
    </div>
  );
};
export default Sidebar;