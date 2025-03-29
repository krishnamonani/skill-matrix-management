import React, { useState } from "react";

function ProfileSection() {
  // Initial user data
  const [userData, setUserData] = useState({
    username: "meet.savaliya",
    firstName: "Meet",
    lastName: "Savaliya",
    contact: "+91 1234567890",
    jobTitle: "Senior Software Engineer",
    department: "Engineering",
    email: "Meet@example.com",
    profilePicture: null,
  });

  // Departments list
  const departments = [
    "Engineering",
    "Product Management",
    "Design",
    "Marketing",
    "Sales",
    "Human Resources",
  ];

  // Handle input changes
  const handleInputChange = (field, value) => {
    setUserData((prev) => ({
      ...prev,
      [field]: value,
    }));
  };

  // Handle profile picture change
  const handleProfilePictureChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        setUserData((prev) => ({
          ...prev,
          profilePicture: reader.result,
        }));
      };
      reader.readAsDataURL(file);
    }
  };

  // Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Updated Profile:", userData);
    alert("Profile Updated Successfully!");
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gradient-to-r from-gray-100 to-gray-200">
      <div className="w-full max-w-3xl bg-white rounded-lg shadow-lg overflow-hidden">
        <div className="bg-gradient-to-r from-blue-500 to-purple-600 text-white px-6 py-4">
          <h2 className="text-2xl font-bold">Profile Settings</h2>
          <p className="text-sm text-blue-100">
            Manage your personal information
          </p>
        </div>

        <div className="p-8">
          <form onSubmit={handleSubmit} className="space-y-6">
            {/* Profile Picture */}
            <div className="flex flex-col items-center space-y-4">
              <div className="w-24 h-24 rounded-full overflow-hidden border-2 border-gray-300">
                {userData.profilePicture ? (
                  <img
                    src={userData.profilePicture}
                    alt="Profile"
                    className="w-full h-full object-cover"
                  />
                ) : (
                  <div className="w-full h-full bg-gray-200 flex items-center justify-center text-gray-500">
                    No Image
                  </div>
                )}
              </div>
              <label className="text-blue-600 font-medium cursor-pointer">
                Change Profile Picture
                <input
                  type="file"
                  accept="image/*"
                  className="hidden"
                  onChange={handleProfilePictureChange}
                />
              </label>
            </div>

            {/* Email (Read-only) */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Email</label>
              <input
                type="email"
                className="md:col-span-2 w-full px-4 py-2 border border-gray-300 rounded-lg bg-gray-100 text-gray-500 cursor-not-allowed"
                value={userData.email}
                readOnly
              />
            </div>

            {/* Username (Read-only) */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Username</label>
              <input
                type="text"
                className="md:col-span-2 w-full px-4 py-2 border border-gray-300 rounded-lg bg-gray-100 text-gray-500 cursor-not-allowed"
                value={userData.username}
                readOnly
              />
            </div>

            {/* First Name and Last Name */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Name</label>
              <div className="md:col-span-2 grid grid-cols-2 gap-4">
                <input
                  type="text"
                  className="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                  placeholder="First Name"
                  value={userData.firstName}
                  onChange={(e) => handleInputChange("firstName", e.target.value)}
                />
                <input
                  type="text"
                  className="w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                  placeholder="Last Name"
                  value={userData.lastName}
                  onChange={(e) => handleInputChange("lastName", e.target.value)}
                />
              </div>
            </div>

            {/* Contact */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Contact Number</label>
              <input
                type="text"
                className="md:col-span-2 w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                value={userData.contact}
                onChange={(e) => handleInputChange("contact", e.target.value)}
              />
            </div>

            {/* Job Title */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Job Title</label>
              <input
                type="text"
                className="md:col-span-2 w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                value={userData.jobTitle}
                onChange={(e) => handleInputChange("jobTitle", e.target.value)}
              />
            </div>

            {/* Department */}
            <div className="grid grid-cols-1 md:grid-cols-3 items-center gap-4">
              <label className="text-gray-700 font-medium">Department</label>
              <select
                className="md:col-span-2 w-full px-4 py-2 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500 focus:border-blue-500"
                value={userData.department}
                onChange={(e) => handleInputChange("department", e.target.value)}
              >
                {departments.map((dept) => (
                  <option key={dept} value={dept}>
                    {dept}
                  </option>
                ))}
              </select>
            </div>

            {/* Submit Button */}
            <div className="flex justify-end">
              <button
                type="submit"
                className="px-6 py-2 bg-gradient-to-r from-blue-500 to-purple-600 text-white font-semibold rounded-lg shadow-md hover:from-blue-600 hover:to-purple-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
              >
                Update Profile
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}

export default ProfileSection;
