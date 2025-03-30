import React, { useState, useEffect } from 'react';
import { User, AlertTriangle, Camera } from 'lucide-react';

const ProfileSettings = () => {
  const [showProfileAlert, setShowProfileAlert] = useState(true);
  const [profileComplete, setProfileComplete] = useState(false);

  const [departmentOptions, setDepartmentOptions] = useState([]);
  const [departmentIds, setDepartmentIds] = useState({});

  const [departmentRoleOptions, setDepartmentRoleOptions] = useState([]);
  const [internalRoleIds, setDepartmentRoleIds] = useState({});

  const [roleOptions, setRoleOptions] = useState([]);
  const [roleIds, setRoleIds] = useState({});

  const [userProfile, setUserProfile] = useState({
    userName: '',
    email: '',
    firstName: '',
    lastName: '',
    phoneNumber: '',
    profilePhoto: null,
    department: '',
    departmentRole: '',
    role: '',
    projectStatus: 'Available'
  });
  
  // Add state for storing the returned user ID after successful API call
  const [userId, setUserId] = useState(null);
  // Add state for API request status
  const [apiStatus, setApiStatus] = useState({
    loading: false,
    error: null,
    success: false
  });

  // Sample options for dropdowns and autocomplete

  const projectStatusOptions = ['Available', 'Busy', 'Stable'];  


  // fetching departments
  useEffect(() => {
    const fetchDepartment = async () => {
      try {
        const response = await fetch(`https://localhost:44302/api/app/app-department/lookup`);
        const result = await response.json();

        if (result.success && Array.isArray(result.data)) {
          setDepartmentOptions(result.data.map(dept => dept.name));

          setDepartmentIds(prevIds => ({
            ...prevIds,
            ...Object.fromEntries(result.data.map(dept => [dept.name, dept.id]))
          }));
        } else {
          console.log("Invalid response format");
        }
      } catch (error) {
        console.log("Error while fetching departments:", error);
      }
    };

    fetchDepartment();
  }, []); 

  // fetching department internal roles
  useEffect(() => {
    const fetchDepartmentRole = async () => {
      try {
        const response = await fetch(`https://localhost:44302/api/app/app-department-internal-role/lookup`);
        const result = await response.json();

        if (result.success && Array.isArray(result.data)) {
          setDepartmentRoleOptions(result.data.map(deptRole => deptRole.departmentRole));

          setDepartmentRoleIds(prevIds => ({
            ...prevIds,
            ...Object.fromEntries(result.data.map(deptRole => [deptRole.departmentRole, deptRole.id]))
          }));
        } else {
          console.log("Invalid response format");
        }
      } catch (error) {
        console.log("Error while fetching department roles:", error);
      }
    };

    fetchDepartmentRole();
  }, []); 

  // fetching roles
  useEffect(() => {
    const fetchRoles = async () => {
      try {
        const response = await fetch(`https://localhost:44302/api/app/app-role/lookup`);
        const result = await response.json();

        if (result.success && Array.isArray(result.data)) {
          setRoleOptions(result.data.map(role => role.roleNameString));

          setRoleIds(prevIds => ({
            ...prevIds,
            ...Object.fromEntries(result.data.map(role => [role.roleNameString, role.id]))
          }));
        } else {
          console.log("Invalid response format");
        }
      } catch (error) {
        console.log("Error while fetching roles:", error);
      }
    };

    fetchRoles();
  }, []); 

  

  // Fetch username and email from the API instead of localStorage
  const fetchUserNameAndEmail = async () => {
    try {
      // Get the initial username or email from localStorage
      const initialUserNameOrEmail = localStorage.getItem('userNameOrEmail');
      
      if (!initialUserNameOrEmail) {
        throw new Error('No Session data Found');
      }
      
      const response = await fetch(`https://localhost:44302/api/app/app-user/user-name-and-email-by-user-name-or-email?userNameOrEmail=${encodeURIComponent(initialUserNameOrEmail)}`);
      
      const data = await response.json();
      
      if (!response.ok || !data.success) {
        throw new Error(data.errorMessage || `Server responded with ${response.status}`);
      }
      
      // Extract username and email from response
      const [userName, email] = data.data;
      
      return { userName, email };
    } catch (error) {
      console.error('Error fetching username and email:', error);
      throw error;
    }
  };

  // Load profile data on component mount
  useEffect(() => {
    const loadProfileData = async () => {
      try {
        // First try to fetch username and email from API
        const { userName, email } = await fetchUserNameAndEmail();
        
        const storedProfileData = localStorage.getItem('userProfileData');
        const storedUserId = localStorage.getItem('UserProfileId');
        
        if (storedProfileData) {
          const parsedData = JSON.parse(storedProfileData);
          // Override with username and email from API
          parsedData.userName = userName;
          parsedData.email = email;
          
          setUserProfile(parsedData);
          
          // Check if required fields are filled to determine profile completeness
          checkProfileCompleteness(parsedData);
        } else {
          // If no stored profile data but we have API info, create a new profile with it
          setUserProfile(prevProfile => ({
            ...prevProfile,
            userName: userName,
            email: email
          }));
        }
        
        if (storedUserId) {
          setUserId(storedUserId);
        }
      } catch (error) {
        // Set API error state
        setApiStatus({
          loading: false,
          error: error.message || 'Failed to load user information',
          success: false
        });
      }
    };
    
    loadProfileData();
  }, []);
  
  // Function to check profile completeness
  const checkProfileCompleteness = (profile) => {
    const requiredFields = ['userName', 'email', 'firstName', 'lastName', 'department', 'role', 'departmentRole'];
    const isComplete = requiredFields.every(field => {
      return profile[field] && profile[field].trim() !== '';
    });
    
    setProfileComplete(isComplete);
    setShowProfileAlert(!isComplete);
  };

  const handleProfileChange = (e) => {
    const { name, value } = e.target;
    
    // Prevent changes to userName and email fields
    if (name === 'userName' || name === 'email') {
      return;
    }
    
    const updatedProfile = {
      ...userProfile,
      [name]: value
    };
    
    setUserProfile(updatedProfile);
    
    // Save to local storage on each change
    localStorage.setItem('userProfileData', JSON.stringify(updatedProfile));
  };

  const handleProfilePhotoUpload = (e) => {
    const file = e.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        const updatedProfile = {
          ...userProfile,
          profilePhoto: reader.result
        };
        
        setUserProfile(updatedProfile);
        
        // Save to local storage after photo upload
        localStorage.setItem('userProfileData', JSON.stringify(updatedProfile));
      };
      reader.readAsDataURL(file);
    }
  };

  const handleProfileSubmit = async (e) => {
    e.preventDefault();
    
    // Check if required fields are filled
    const requiredFields = ['userName', 'email', 'firstName', 'lastName', 'department', 'role', 'departmentRole'];
    const isComplete = requiredFields.every(field => {
      return userProfile[field] && userProfile[field].trim() !== '';
    });
    
    setProfileComplete(isComplete);
    setShowProfileAlert(!isComplete);
    
    if (isComplete) {
      // Set loading state
      setApiStatus({
        loading: true,
        error: null,
        success: false
      });
      
      try {
        // Create request payload
        const payload = {
          firstName: userProfile.firstName,
          lastName: userProfile.lastName,
          email: userProfile.email,
          phoneNumber: userProfile.phoneNumber || "",
          roleId: roleIds[userProfile.role] , 
          departmentId: departmentIds[userProfile.department] , 
          internalRoleId: internalRoleIds[userProfile.departmentRole] ,
          isAvailable: userProfile.projectStatus === 'Busy' ? 0 : (userProfile.projectStatus === 'Stable' ? 1 : 2),
          profilePhoto: userProfile.profilePhoto || "string"
        };
        
        // Make API request
        const response = await fetch('https://localhost:44302/api/app/app-user/or-update-user', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(payload)
        });
        
        const data = await response.json();
        
        if (!response.ok || !data.success) {
          throw new Error(data.errorMessage || `Server responded with ${response.status}`);
        }
        
        // Store the user ID from the response
        if (data && data.id) {
          // Set user ID in state
          setUserId(data.id);
          
          // Store user ID in local storage
          localStorage.setItem('UserProfileId', data.id);
          
          // Update the profile data in local storage with the ID
          const updatedProfile = {
            ...userProfile,
            userId: data.id
          };
          localStorage.setItem('userProfileData', JSON.stringify(updatedProfile));
          
          console.log('User ID stored in local storage:', data.id);
        }
        
        // Update status
        setApiStatus({
          loading: false,
          error: null,
          success: true
        });
        
        console.log('Profile saved:', userProfile);
        console.log('API response:', data);
      } catch (error) {
        console.error('Error saving profile:', error);
        
        // Update status with error
        setApiStatus({
          loading: false,
          error: error.message || 'Failed to save profile',
          success: false
        });
      }
    }
  };

  return (
    <div className="bg-white rounded-lg shadow-md border border-slate-200">
      <div className="p-6 border-b border-slate-200">
        <h3 className="text-xl font-semibold text-indigo-800">Profile Settings</h3>
        <p className="text-sm text-slate-500 mt-1">Complete your profile to access other dashboard features</p>
      </div>

      {/* Profile completion alert */}
      {showProfileAlert && (
        <div className="mx-6 mt-6 p-4 bg-amber-50 border border-amber-200 rounded-lg flex items-start">
          <AlertTriangle className="text-amber-500 mr-3 flex-shrink-0 mt-0.5" size={20} />
          <div>
            <h4 className="font-medium text-amber-800">Profile Incomplete</h4>
            <p className="text-sm text-amber-700">Please complete all required fields in your profile before accessing other sections of the dashboard.</p>
          </div>
        </div>
      )}
      
      {/* API Status Alerts */}
      {apiStatus.success && (
        <div className="mx-6 mt-6 p-4 bg-green-50 border border-green-200 rounded-lg">
          <h4 className="font-medium text-green-800">Profile Saved Successfully</h4>
          {userId && (
            <p className="text-sm text-green-700">Your profile has been saved with ID: {userId}</p>
          )}
        </div>
      )}
      
      {apiStatus.error && (
        <div className="mx-6 mt-6 p-4 bg-rose-50 border border-rose-200 rounded-lg">
          <h4 className="font-medium text-rose-800">Error Saving Profile</h4>
          <p className="text-sm text-rose-700">{apiStatus.error}</p>
        </div>
      )}

      <form onSubmit={handleProfileSubmit} className="p-6">
        {/* Profile Photo Upload */}
        <div className="mb-8 flex flex-col items-center">
          <div className="relative mb-4">
            <div className="h-32 w-32 rounded-full bg-indigo-50 flex items-center justify-center overflow-hidden border-4 border-indigo-100">
              {userProfile.profilePhoto ? (
                <img
                  src={userProfile.profilePhoto}
                  alt="Profile"
                  className="h-full w-full object-cover"
                />
              ) : (
                <User size={64} className="text-indigo-300" />
              )}
            </div>
            <label 
              htmlFor="profile-photo" 
              className="absolute bottom-0 right-0 bg-indigo-600 text-white p-2 rounded-full cursor-pointer hover:bg-indigo-700 transition-colors"
            >
              <Camera size={16} />
            </label>
            <input
              type="file"
              id="profile-photo"
              className="hidden"
              accept="image/*"
              onChange={handleProfilePhotoUpload}
            />
          </div>
          <p className="text-sm text-slate-500">Click the camera icon to upload a profile photo</p>
        </div>

        {/* Profile Form */}
        <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
          {/* Username - READ ONLY */}
          <div>
            <label htmlFor="userName" className="block text-sm font-medium text-slate-700 mb-1">
              Username <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="userName"
              name="userName"
              value={userProfile.userName}
              readOnly
              className="w-full p-2 border border-slate-300 rounded-md bg-slate-50 cursor-not-allowed"
            />
            <p className="mt-1 text-xs text-slate-500">Username cannot be changed</p>
          </div>

          {/* Email - READ ONLY */}
          <div>
            <label htmlFor="email" className="block text-sm font-medium text-slate-700 mb-1">
              Email <span className="text-rose-500">*</span>
            </label>
            <input
              type="email"
              id="email"
              name="email"
              value={userProfile.email}
              readOnly
              className="w-full p-2 border border-slate-300 rounded-md bg-slate-50 cursor-not-allowed"
            />
            <p className="mt-1 text-xs text-slate-500">Email cannot be changed</p>
          </div>

          {/* First Name */}
          <div>
            <label htmlFor="firstName" className="block text-sm font-medium text-slate-700 mb-1">
              First Name <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              value={userProfile.firstName}
              onChange={handleProfileChange}
              required
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>

          {/* Last Name */}
          <div>
            <label htmlFor="lastName" className="block text-sm font-medium text-slate-700 mb-1">
              Last Name <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="lastName"
              name="lastName"
              value={userProfile.lastName}
              onChange={handleProfileChange}
              required
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>
          
          {/* Phone Number */}
          <div>
            <label htmlFor="phoneNumber" className="block text-sm font-medium text-slate-700 mb-1">
              Phone Number
            </label>
            <input
              type="tel"
              id="phoneNumber"
              name="phoneNumber"
              value={userProfile.phoneNumber}
              onChange={handleProfileChange}
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
          </div>

          {/* Department - Autocomplete */}
          <div>
            <label htmlFor="department" className="block text-sm font-medium text-slate-700 mb-1">
              Department <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="department"
              name="department"
              value={userProfile.department}
              onChange={handleProfileChange}
              list="department-options"
              required
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
            <datalist id="department-options">
              {departmentOptions.map(option => (
                <option key={option} value={option} />
              ))}
            </datalist>
          </div>

          {/* Role - Autocomplete */}
          <div>
            <label htmlFor="role" className="block text-sm font-medium text-slate-700 mb-1">
              Role <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="role"
              name="role"
              value={userProfile.role}
              onChange={handleProfileChange}
              list="role-options"
              required
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
            <datalist id="role-options">
              {roleOptions.map(option => (
                <option key={option} value={option} />
              ))}
            </datalist>
          </div>

          {/* Department Internal Role - Autocomplete - No longer dependent on department */}
          <div>
            <label htmlFor="departmentRole" className="block text-sm font-medium text-slate-700 mb-1">
              Department Role <span className="text-rose-500">*</span>
            </label>
            <input
              type="text"
              id="departmentRole"
              name="departmentRole"
              value={userProfile.departmentRole}
              onChange={handleProfileChange}
              list="department-role-options"
              required
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            />
            <datalist id="department-role-options">
              {departmentRoleOptions.map(option => (
                <option key={option} value={option} />
              ))}
            </datalist>
          </div>

          {/* Project Status */}
          <div>
            <label htmlFor="projectStatus" className="block text-sm font-medium text-slate-700 mb-1">
              Project Status
            </label>
            <select
              id="projectStatus"
              name="projectStatus"
              value={userProfile.projectStatus}
              onChange={handleProfileChange}
              className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
            >
              {projectStatusOptions.map(option => (
                <option key={option} value={option}>{option}</option>
              ))}
            </select>
          </div>
        </div>

        {/* Save Button */}
        <div className="mt-8">
          <button 
            type="submit"
            className="bg-indigo-600 text-white px-6 py-2 rounded-md hover:bg-indigo-700 transition-colors"
            disabled={apiStatus.loading}
          >
            {apiStatus.loading ? 'Saving...' : 'Save Profile'}
          </button>
          {!profileComplete && (
            <p className="mt-2 text-sm text-rose-600">* Required fields must be completed</p>
          )}
        </div>
      </form>
    </div>
  );
};

export default ProfileSettings;