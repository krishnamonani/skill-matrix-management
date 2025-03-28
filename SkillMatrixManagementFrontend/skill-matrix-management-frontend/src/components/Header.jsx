import React from "react";

const Header = () => {
  return (
    <header className="flex justify-between items-center bg-gray-100 p-4 shadow-md">
      <h1 className="text-xl font-bold text-blue-500">
        Skill <span className="text-green-500">Matrix</span>
      </h1>
      <div className="flex items-center">
        <img
          src="https://th.bing.com/th/id/OIP.IGNf7GuQaCqz_RPq5wCkPgHaLH?w=204&h=306&c=8&rs=1&qlt=90&o=6&pid=3.1&rm=2"
          alt="User Avatar"
          className="w-9 h-9 rounded-full object-cover mr-2"
        />
        <span className="font-medium">User 1</span>
      </div>
    </header>
  );
};

export default Header;
