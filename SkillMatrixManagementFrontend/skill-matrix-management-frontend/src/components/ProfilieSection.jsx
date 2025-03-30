import React, { useState, useEffect } from 'react';
import { User, Mail, Phone, Building, Briefcase, Calendar, Upload, X, Check } from 'lucide-react';
import axios from 'axios';

const ProfileSection = () => {
  // User profile state
  const [profile, setProfile] = useState({
    email: '',
    firstName: '',
    lastName: '',
    username: '',
    phoneNumber: '',
    department: '',
    role: '',
    departmentRole: '',
    projectStatus: 'available', // default value
    profilePhoto: null
  });

  // Autocomplete options (would normally come from API)
  const [departmentOptions, setDepartmentOptions] = useState([]);
  const [roleOptions, setRoleOptions] = useState([]);
  const [departmentRoleOptions, setDepartmentRoleOptions] = useState([]);

  // Search terms for autocomplete
  const [departmentSearch, setDepartmentSearch] = useState('');
  const [roleSearch, setRoleSearch] = useState('');
  const [departmentRoleSearch, setDepartmentRoleSearch] = useState('');

  // UI states
  const [photoPreview, setPhotoPreview] = useState(null);
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [successMessage, setSuccessMessage] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  const [showDepartmentDropdown, setShowDepartmentDropdown] = useState(false);
  const [showRoleDropdown, setShowRoleDropdown] = useState(false);
  const [showDepartmentRoleDropdown, setShowDepartmentRoleDropdown] = useState(false);

  // Fetch initial data - departments, roles, etc.
  useEffect(() => {
    // Simulated API calls - in real app, these would be actual API endpoints
    const fetchDepartments = async () => {
      try {
        // Mock data for demonstration
        const departments = [
          'Engineering', 'Marketing', 'Sales', 'Finance', 
          'Human Resources', 'Product', 'Design', 'Customer Support'
        ];
        setDepartmentOptions(departments);
      } catch (error) {
        console.error('Error fetching departments:', error);
      }
    };

    const fetchRoles = async () => {
      try {
        // Mock data for demonstration
        const roles = [
          'Software Engineer', 'Product Manager', 'UX Designer', 
          'Data Scientist', 'Marketing Specialist', 'Sales Representative',
          'HR Manager', 'Financial Analyst'
        ];
        setRoleOptions(roles);
      } catch (error) {
        console.error('Error fetching roles:', error);
      }
    };

    const fetchDepartmentRoles = async () => {
      try {
        // Mock data for demonstration
        const departmentRoles = [
          'Team Lead', 'Junior', 'Senior', 'Manager', 
          'Director', 'VP', 'Associate', 'Intern'
        ];
        setDepartmentRoleOptions(departmentRoles);
      } catch (error) {
        console.error('Error fetching department roles:', error);
      }
    };

    // Fetch user profile data
    const fetchUserProfile = async () => {
      try {
        // In a real app, this would be an API call
        // Mock user data for demonstration
        const userData = {
          email: 'user@example.com',
          firstName: 'John',
          lastName: 'Doe',
          username: 'johndoe',
          phoneNumber: '(123) 456-7890',
          department: 'Engineering',
          role: 'Software Engineer',
          departmentRole: 'Senior',
          projectStatus: 'stable',
          profilePhoto: null
        };
        setProfile(userData);
        
        // Set search terms for autocomplete fields
        setDepartmentSearch(userData.department);
        setRoleSearch(userData.role);
        setDepartmentRoleSearch(userData.departmentRole);
      } catch (error) {
        console.error('Error fetching user profile:', error);
        setErrorMessage('Failed to load user profile data.');
      }
    };

    fetchDepartments();
    fetchRoles();
    fetchDepartmentRoles();
    fetchUserProfile();
  }, []);

  // Handle input changes
  const handleChange = (e) => {
    const { name, value } = e.target;
    setProfile({
      ...profile,
      [name]: value
    });
  };

  // Handle autocomplete selections
  const handleSelectDepartment = (department) => {
    setProfile({ ...profile, department });
    setDepartmentSearch(department);
    setShowDepartmentDropdown(false);
  };

  const handleSelectRole = (role) => {
    setProfile({ ...profile, role });
    setRoleSearch(role);
    setShowRoleDropdown(false);
  };

  const handleSelectDepartmentRole = (departmentRole) => {
    setProfile({ ...profile, departmentRole });
    setDepartmentRoleSearch(departmentRole);
    setShowDepartmentRoleDropdown(false);
  };

  // Filter options based on search term
  const filteredDepartments = departmentOptions.filter(dept => 
    dept.toLowerCase().includes(departmentSearch.toLowerCase())
  );
  
  const filteredRoles = roleOptions.filter(role => 
    role.toLowerCase().includes(roleSearch.toLowerCase())
  );
  
  const filteredDepartmentRoles = departmentRoleOptions.filter(role => 
    role.toLowerCase().includes(departmentRoleSearch.toLowerCase())
  );

  // Handle profile photo change
  const handlePhotoChange = (e) => {
    const file = e.target.files[0];
    if (file) {
      setProfile({ ...profile, profilePhoto: file });
      const reader = new FileReader();
      reader.onload = () => {
        setPhotoPreview(reader.result);
      };
      reader.readAsDataURL(file);
    }
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsSubmitting(true);
    setErrorMessage('');
    setSuccessMessage('');

    try {
      // In a real app, this would be an API call to update the profile
      // Simulated API call with timeout to demonstrate loading state
      await new Promise(resolve => setTimeout(resolve, 1000));
      
      // Simulated success response
      console.log('Profile updated:', profile);
      setSuccessMessage('Profile updated successfully!');
      
      // Clear success message after 3 seconds
      setTimeout(() => {
        setSuccessMessage('');
      }, 3000);
    } catch (error) {
      console.error('Error updating profile:', error);
      setErrorMessage('Failed to update profile. Please try again.');
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <div className="max-w-4xl mx-auto p-6 bg-white rounded-lg shadow-md">
      <h2 className="text-2xl font-bold text-gray-800 mb-6">Profile Information</h2>
      
      {successMessage && (
        <div className="mb-4 p-3 bg-green-100 text-green-700 rounded-md flex items-center">
          <Check size={18} className="mr-2" />
          {successMessage}
        </div>
      )}
      
      {errorMessage && (
        <div className="mb-4 p-3 bg-red-100 text-red-700 rounded-md flex items-center">
          <X size={18} className="mr-2" />
          {errorMessage}
        </div>
      )}
      
      <form onSubmit={handleSubmit} className="space-y-6">
        {/* Profile Photo Section */}
        <div className="flex items-start space-x-6">
          <div className="flex-shrink-0">
            <div className="relative h-32 w-32 rounded-full overflow-hidden bg-gray-100 border border-gray-300">
              {photoPreview ? (
                <img 
                  src={photoPreview} 
                  alt="Profile Preview" 
                  className="h-full w-full object-cover"
                />
              ) : (
                <div className="h-full w-full flex items-center justify-center bg-gray-200">
                  <User size={64} className="text-gray-400" />
                </div>
              )}
            </div>
            <label className="block mt-4">
              <span className="sr-only">Choose profile photo</span>
              <input 
                type="file" 
                className="block w-full text-sm text-gray-500
                  file:mr-4 file:py-2 file:px-4
                  file:rounded-full file:border-0
                  file:text-sm file:font-semibold
                  file:bg-blue-50 file:text-blue-700
                  hover:file:bg-blue-100"
                accept="image/*"
                onChange={handlePhotoChange}
              />
            </label>
          </div>
          
          <div className="flex-grow space-y-4">
            {/* Username and Email */}
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label htmlFor="username" className="block text-sm font-medium text-gray-700 mb-1">
                  Username
                </label>
                <div className="relative">
                  <User size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
                  <input
                    type="text"
                    id="username"
                    name="username"
                    value={profile.username}
                    onChange={handleChange}
                    className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
                    required
                  />
                </div>
              </div>
              
              <div>
                <label htmlFor="email" className="block text-sm font-medium text-gray-700 mb-1">
                  Email
                </label>
                <div className="relative">
                  <Mail size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
                  <input
                    type="email"
                    id="email"
                    name="email"
                    value={profile.email}
                    onChange={handleChange}
                    className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
                    required
                  />
                </div>
              </div>
            </div>
            
            {/* First Name and Last Name */}
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div>
                <label htmlFor="firstName" className="block text-sm font-medium text-gray-700 mb-1">
                  First Name
                </label>
                <input
                  type="text"
                  id="firstName"
                  name="firstName"
                  value={profile.firstName}
                  onChange={handleChange}
                  className="w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
                  required
                />
              </div>
              
              <div>
                <label htmlFor="lastName" className="block text-sm font-medium text-gray-700 mb-1">
                  Last Name
                </label>
                <input
                  type="text"
                  id="lastName"
                  name="lastName"
                  value={profile.lastName}
                  onChange={handleChange}
                  className="w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
                  required
                />
              </div>
            </div>
          </div>
        </div>
        
        {/* Phone Number */}
        <div>
          <label htmlFor="phoneNumber" className="block text-sm font-medium text-gray-700 mb-1">
            Phone Number
          </label>
          <div className="relative">
            <Phone size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
            <input
              type="tel"
              id="phoneNumber"
              name="phoneNumber"
              value={profile.phoneNumber}
              onChange={handleChange}
              className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
            />
          </div>
        </div>
        
        {/* Department - Autocomplete */}
        <div>
          <label htmlFor="department" className="block text-sm font-medium text-gray-700 mb-1">
            Department
          </label>
          <div className="relative">
            <Building size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
            <input
              type="text"
              id="department"
              value={departmentSearch}
              onChange={(e) => {
                setDepartmentSearch(e.target.value);
                setShowDepartmentDropdown(true);
              }}
              onFocus={() => setShowDepartmentDropdown(true)}
              className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
            />
            {showDepartmentDropdown && filteredDepartments.length > 0 && (
              <div className="absolute z-10 mt-1 w-full bg-white shadow-lg max-h-60 rounded-md py-1 text-base overflow-auto focus:outline-none sm:text-sm">
                {filteredDepartments.map((dept, index) => (
                  <div
                    key={index}
                    onClick={() => handleSelectDepartment(dept)}
                    className="cursor-pointer select-none relative py-2 pl-3 pr-9 hover:bg-blue-50"
                  >
                    {dept}
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
        
        {/* Role - Autocomplete */}
        <div>
          <label htmlFor="role" className="block text-sm font-medium text-gray-700 mb-1">
            Role
          </label>
          <div className="relative">
            <Briefcase size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
            <input
              type="text"
              id="role"
              value={roleSearch}
              onChange={(e) => {
                setRoleSearch(e.target.value);
                setShowRoleDropdown(true);
              }}
              onFocus={() => setShowRoleDropdown(true)}
              className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
            />
            {showRoleDropdown && filteredRoles.length > 0 && (
              <div className="absolute z-10 mt-1 w-full bg-white shadow-lg max-h-60 rounded-md py-1 text-base overflow-auto focus:outline-none sm:text-sm">
                {filteredRoles.map((role, index) => (
                  <div
                    key={index}
                    onClick={() => handleSelectRole(role)}
                    className="cursor-pointer select-none relative py-2 pl-3 pr-9 hover:bg-blue-50"
                  >
                    {role}
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
        
        {/* Department Role - Autocomplete */}
        <div>
          <label htmlFor="departmentRole" className="block text-sm font-medium text-gray-700 mb-1">
            Department Role
          </label>
          <div className="relative">
            <Building size={18} className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400" />
            <input
              type="text"
              id="departmentRole"
              value={departmentRoleSearch}
              onChange={(e) => {
                setDepartmentRoleSearch(e.target.value);
                setShowDepartmentRoleDropdown(true);
              }}
              onFocus={() => setShowDepartmentRoleDropdown(true)}
              className="pl-10 w-full rounded-md border border-gray-300 py-2 px-3 shadow-sm focus:border-blue-500 focus:outline-none focus:ring-1 focus:ring-blue-500"
            />
            {showDepartmentRoleDropdown && filteredDepartmentRoles.length > 0 && (
              <div className="absolute z-10 mt-1 w-full bg-white shadow-lg max-h-60 rounded-md py-1 text-base overflow-auto focus:outline-none sm:text-sm">
                {filteredDepartmentRoles.map((role, index) => (
                  <div
                    key={index}
                    onClick={() => handleSelectDepartmentRole(role)}
                    className="cursor-pointer select-none relative py-2 pl-3 pr-9 hover:bg-blue-50"
                  >
                    {role}
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
        
        {/* Project Status */}
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Project Status
          </label>
          <div className="flex items-center space-x-4">
            <div className="flex items-center">
              <input
                id="available"
                name="projectStatus"
                type="radio"
                value="available"
                checked={profile.projectStatus === 'available'}
                onChange={handleChange}
                className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300"
              />
              <label htmlFor="available" className="ml-2 block text-sm text-gray-700">
                Available
              </label>
            </div>
            <div className="flex items-center">
              <input
                id="stable"
                name="projectStatus"
                type="radio"
                value="stable"
                checked={profile.projectStatus === 'stable'}
                onChange={handleChange}
                className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300"
              />
              <label htmlFor="stable" className="ml-2 block text-sm text-gray-700">
                Stable
              </label>
            </div>
            <div className="flex items-center">
              <input
                id="busy"
                name="projectStatus"
                type="radio"
                value="busy"
                checked={profile.projectStatus === 'busy'}
                onChange={handleChange}
                className="h-4 w-4 text-blue-600 focus:ring-blue-500 border-gray-300"
              />
              <label htmlFor="busy" className="ml-2 block text-sm text-gray-700">
                Busy
              </label>
            </div>
          </div>
        </div>
        
        {/* Submit Button */}
        <div className="flex justify-end">
          <button
            type="submit"
            disabled={isSubmitting}
            className={`px-4 py-2 rounded-md text-white font-medium 
              ${isSubmitting ? 'bg-blue-400 cursor-not-allowed' : 'bg-blue-600 hover:bg-blue-700'} 
              focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500`}
          >
            {isSubmitting ? 'Saving...' : 'Save Changes'}
          </button>
        </div>
      </form>
    </div>
  );
};

export default ProfileSection;