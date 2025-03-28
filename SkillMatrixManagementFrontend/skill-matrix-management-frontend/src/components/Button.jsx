import React from "react";

const Button = ({ children, variant = "primary", onClick }) => {
  const baseStyles = "px-4 py-2 rounded text-sm font-medium transition";
  const variants = {
    primary: "bg-blue-500 text-white hover:bg-blue-600",
    outline: "border border-blue-500 text-blue-500 hover:bg-blue-100",
    danger: "bg-red-500 text-white hover:bg-red-600",
  };

  return (
    <button onClick={onClick} className={`${baseStyles} ${variants[variant]}`}>
      {children}
    </button>
  );
};

export default Button;
