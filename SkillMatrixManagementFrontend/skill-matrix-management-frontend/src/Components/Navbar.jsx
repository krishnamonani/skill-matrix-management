import React from 'react';
import './Navbar.css';  // For styling the navbar
const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="left-side">
        <h1>Welcome to Skill Matrix</h1>
      </div>
      <div className="right-side">
        <img
          src="" // Replace with your profile image URL
          alt="Profile"
          className="profile-img"
        />
        <span className="profile-name">John Doe</span>
      </div>
    </nav>
  );
};
export default Navbar;