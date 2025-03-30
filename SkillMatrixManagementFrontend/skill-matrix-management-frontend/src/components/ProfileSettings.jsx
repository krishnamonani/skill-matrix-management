import React, { useState, useEffect } from 'react';
import { User, AlertTriangle, Camera } from 'lucide-react';

const ProfileSettings = () => {
  const [showProfileAlert, setShowProfileAlert] = useState(true);
  const [profileComplete, setProfileComplete] = useState(false);
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
  const departmentOptions = ['Engineering', 'Marketing', 'Sales', 'Finance', 'Human Resources', 'Operations'];
  const roleOptions = ['Developer', 'Manager', 'Hr'];
  const projectStatusOptions = ['Available', 'Busy', 'Stable'];
  
  // Department role options - Now a flat list instead of being department-dependent
  const departmentRoleOptions = [
    'Software Engineer', 'QA Engineer', 'DevOps Engineer', 'Technical Lead',
    'Marketing Specialist', 'Content Creator', 'SEO Analyst', 'Campaign Manager',
    'Sales Representative', 'Account Manager', 'Sales Analyst', 'Business Developer',
    'Financial Analyst', 'Accountant', 'Payroll Specialist', 'Tax Consultant',
    'HR Coordinator', 'Recruiter', 'Benefits Specialist', 'Employee Relations',
    'Operations Manager', 'Logistics Coordinator', 'Supply Chain Analyst', 'Facility Manager'
  ];
  
  // Sample IDs mapping for departments, roles and internal roles
  // In a real application, these would likely be fetched from an API
  const departmentIds = {
    'Engineering': '3a18d3e9-66fc-5396-d7ba-b4ad87d4d535',
    'Marketing': '4b29e4f9-77ac-6487-e8cb-c5d098e2f646',
    'Sales': '5c30f5g0-88bd-7598-f9dc-d6e109f3g757',
    'Finance': '6d41g6h1-99ce-8609-g0ed-e7f210g4h868',
    'Human Resources': '7e52h7i2-00df-9710-h1fe-f8g321h5i979',
    'Operations': '8f63i8j3-11eg-0821-i2gf-g9h432i6j080'
  };
  
  const roleIds = {
    'Manager': '5c30f5g0-8d54-db2-f8c9-4e1hf03gh2d8',
    'Developer': '3a18d3e9-6b32-b9b0-d6a7-2c9fd81ef0b6',
    'Hr': '7e52h7i2-0f76-fd4-h0e1-6g3jh25ij4f0'
  };
  
  const internalRoleIds = {
    'Software Engineer': '3a18d0a2-f635-f198-c056-51f6e13b9a4d',
    'QA Engineer': '4b29e1b3-g746-g209-d167-62g7f24b0b5e',
    'DevOps Engineer': '5c30f2c4-h857-h310-e278-73h8g35c1c6f',
    'Technical Lead': '6d41g3d5-i968-i421-f389-84i9h46d2d7g',
    'Marketing Specialist': '7e52h4e6-j079-j532-g490-95j0i57e3e8h',
    'Content Creator': '8f63i5f7-k180-k643-h501-06k1j68f4f9i',
    'SEO Analyst': '9g74j6g8-l291-l754-i612-17l2k79g5g0j',
    'Campaign Manager': '0h85k7h9-m302-m865-j723-28m3l80h6h1k',
    'Sales Representative': '1i96l8i0-n413-n976-k834-39n4m91i7i2l',
    'Account Manager': '2j07m9j1-o524-o087-l945-40o5n02j8j3m',
    'Sales Analyst': '3k18n0k2-p635-p198-m056-51p6o13k9k4n',
    'Business Developer': '4l29o1l3-q746-q209-n167-62q7p24l0l5o',
    'Financial Analyst': '5m30p2m4-r857-r310-o278-73r8q35m1m6p',
    'Accountant': '6n41q3n5-s968-s421-p389-84s9r46n2n7q',
    'Payroll Specialist': '7o52r4o6-t079-t532-q490-95t0s57o3o8r',
    'Tax Consultant': '8p63s5p7-u180-u643-r501-06u1t68p4p9s',
    'HR Coordinator': '9q74t6q8-v291-v754-s612-17v2u79q5q0t',
    'Recruiter': '0r85u7r9-w302-w865-t723-28w3v80r6r1u',
    'Benefits Specialist': '1s96v8s0-x413-x976-u834-39x4w91s7s2v',
    'Employee Relations': '2t07w9t1-y524-y087-v945-40y5x02t8t3w',
    'Operations Manager': '3u18x0u2-z635-z198-w056-51z6y13u9u4x',
    'Logistics Coordinator': '4v29y1v3-a746-a209-x167-62a7z24v0v5y',
    'Supply Chain Analyst': '5w30z2w4-b857-b310-y278-73b8a35w1w6z',
    'Facility Manager': '6x41a3x5-c968-c421-z389-84c9b46x2x7a'
  };

  // Load profile data from local storage on component mount
  useEffect(() => {
    const storedProfileData = localStorage.getItem('userProfileData');
    const storedUserId = localStorage.getItem('UserProfileId');
    
    // Get username and email from localStorage (saved during login)
    const userName = localStorage.getItem('userName');
    const userEmail = localStorage.getItem('userEmail');
    
    if (storedProfileData) {
      const parsedData = JSON.parse(storedProfileData);
      // Override with username and email from login if available
      if (userName && userEmail) {
        parsedData.userName = userName;
        parsedData.email = userEmail;
      }
      setUserProfile(parsedData);
      
      // Check if required fields are filled to determine profile completeness
      checkProfileCompleteness(parsedData);
    } else if (userName && userEmail) {
      // If no stored profile data but we have login info, create a new profile with it
      setUserProfile(prevProfile => ({
        ...prevProfile,
        userName: userName,
        email: userEmail
      }));
    }
    
    if (storedUserId) {
      setUserId(storedUserId);
    }
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
      return userProfile[field].trim() !== '';
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
          roleId: roleIds[userProfile.role] || "3a18d3e9-6b32-b9b0-d6a7-2c9fd81ef0b6", // Default to Developer if not found
          departmentId: departmentIds[userProfile.department] || "3a18d3e9-66fc-5396-d7ba-b4ad87d4d535", // Default to Engineering if not found
          internalRoleId: internalRoleIds[userProfile.departmentRole] || "3a18d0a2-f635-f198-c056-51f6e13b9a4d", // Use department role mapping
          isAvailable: userProfile.projectStatus === 'Available' ? 1 : 0,
          profilePhoto: userProfile.profilePhoto || "string"
        };
        
        // Make API request
        const response = await fetch('https://localhost:44302/api/app/app-user', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(payload)
        });
        
        if (!response.ok) {
          throw new Error(`Server responded with ${response.status}`);
        }
        
        const data = await response.json();
        
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