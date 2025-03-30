import React, { useState, useEffect } from 'react';
import { User, Home, BookOpen, Settings, LogOut, Edit2, Trash2, PlusCircle, ChevronDown, Upload, Camera, AlertTriangle } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

const SkillDashboard = () => {
    const [sidebarOpen, setSidebarOpen] = useState(false);
    const [profileOpen, setProfileOpen] = useState(false);
    const [skills, setSkills] = useState([
        { id: 1, name: 'React', level: 'Advanced' },
        { id: 2, name: 'TypeScript', level: 'Intermediate' },
        { id: 3, name: 'Tailwind CSS', level: 'Expert' },
    ]);
    const [currentPage, setCurrentPage] = useState('Profile'); // Default to Profile page
    const [newSkill, setNewSkill] = useState('');
    const [newLevel, setNewLevel] = useState('Beginner');
    const [editingId, setEditingId] = useState(null);
    const [editSkill, setEditSkill] = useState('');
    const [editLevel, setEditLevel] = useState('');
    const [profileComplete, setProfileComplete] = useState(false);
    const [showProfileAlert, setShowProfileAlert] = useState(false);
    const [isSubmitting, setIsSubmitting] = useState(false);
    const navigate = useNavigate();

    // User profile state
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

    // Autocomplete data
    const departmentOptions = ['Engineering', 'Design', 'Product', 'Marketing', 'Sales', 'HR', 'Finance'];
    const roleOptions = ['Frontend Developer', 'Backend Developer', 'Full Stack Developer', 'UX Designer', 'Product Manager', 'QA Engineer', 'DevOps Engineer'];
    const projectStatusOptions = ['Available', 'Busy', 'Stable'];

    const skillSuggestions = ['JavaScript', 'HTML', 'CSS', 'Node.js', 'Next.js', 'Vue.js', 'Angular', 'Python', 'Java'];

     // Check if all required profile fields are filled
     useEffect(() => {
        const requiredFields = ['userName', 'email', 'firstName', 'lastName', 'department', 'role', 'phoneNumber', 'departmentRole'];
        const allFieldsFilled = requiredFields.every(field => userProfile[field].trim() !== '');
        setProfileComplete(allFieldsFilled);
    }, [userProfile]);

    // Function to handle page navigation with profile check
    const handlePageNavigation = (page) => {
        if (page !== 'Profile' && !profileComplete) {
            setShowProfileAlert(true);
            // Force profile page to be active
            setCurrentPage('Profile');
        } else {
            setCurrentPage(page);
            setSidebarOpen(false);
        }
    };

    const handleAddSkill = () => {
        if (newSkill.trim()) {
            setSkills([...skills, {
                id: skills.length ? Math.max(...skills.map(s => s.id)) + 1 : 1,
                name: newSkill,
                level: newLevel
            }]);
            setNewSkill('');
            setNewLevel('Beginner');
        }
    };

    const handleDeleteSkill = (id) => {
        setSkills(skills.filter(skill => skill.id !== id));
    };

    const startEditing = (skill) => {
        setEditingId(skill.id);
        setEditSkill(skill.name);
        setEditLevel(skill.level);
    };

    const saveEdit = () => {
        if (editSkill.trim()) {
            setSkills(skills.map(skill =>
                skill.id === editingId ? { ...skill, name: editSkill, level: editLevel } : skill
            ));
            setEditingId(null);
        }
    };

    const handleProfileChange = (e) => {
        const { name, value } = e.target;
        setUserProfile({
            ...userProfile,
            [name]: value
        });
        // Hide alert when user is editing profile
        setShowProfileAlert(false);
    };

    const handleProfilePhotoUpload = (e) => {
        if (e.target.files && e.target.files[0]) {
            // In a real application, you would handle the file upload to your backend
            // For now, we'll just store the file object
            setUserProfile({
                ...userProfile,
                profilePhoto: URL.createObjectURL(e.target.files[0])
            });
        }
    };

    const handleProfileSubmit = async(e) => {
        e.preventDefault();
        
        if (!profileComplete) {
            setShowProfileAlert(true);
            return;
        }
        
        try {
            setIsSubmitting(true);
            
            // Convert profilePhoto to base64 string if it exists
            let photoData = userProfile.profilePhoto || 'string';
            if (userProfile.profilePhoto && userProfile.profilePhoto instanceof File) {
                photoData = await new Promise((resolve, reject) => {
                    const reader = new FileReader();
                    reader.readAsDataURL(userProfile.profilePhoto);
                    reader.onload = () => resolve(reader.result);
                    reader.onerror = error => reject(error);
                });
            }
            
            // Prepare the request payload
            const profileData = {
                firstName: userProfile.firstName,
                lastName: userProfile.lastName,
                email: userProfile.email,
                phoneNumber: userProfile.phoneNumber,
                roleId: userProfile.role, // Map role to roleId if needed
                departmentId: userProfile.department, // Map department to departmentId if needed
                internalRoleId: userProfile.departmentRole, // Internal role within department
                isAvailable: userProfile.projectStatus === 'Available' ? 1 : 0,
                profilePhoto: photoData,
                userName: userProfile.userName
            };
            
            // Save skills along with profile if your API supports it
            const skillsData = skills.map(skill => ({
                name: skill.name,
                level: skill.level
            }));
            
            // Make the API request
            const response = await fetch('https://localhost:44302/api/app/app-user', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    ...profileData,
                    skills: skillsData
                }),
            });
            
            if (!response.ok) {
                throw new Error(`API request failed with status ${response.status}`);
            }
            
            const data = await response.json();
            
            if (data && data.id) {
                localStorage.setItem('ProfileId', data.id);
                alert('Profile saved successfully!');
                
                // Optionally navigate to home page after successful save
                setCurrentPage('Home');
            } else {
                throw new Error('No ID returned from server');
            }
        } catch (error) {
            console.error('Error saving profile:', error);
            alert(`An error occurred while saving the profile: ${error.message}`);
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <div className="flex h-screen bg-slate-50">
            {/* Mobile sidebar toggle */}
            <button
                className="p-2 rounded-md md:hidden fixed top-4 left-4 z-20 bg-indigo-600 text-white"
                onClick={() => setSidebarOpen(!sidebarOpen)}
            >
                <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
                </svg>
            </button>

            {/* Sidebar */}
            <aside
                className={`bg-gray-700 text-gray-200 w-64 flex-shrink-0 fixed inset-y-0 left-0 transform transition-transform duration-300 ease-in-out z-10 md:translate-x-0 ${
                    sidebarOpen ? 'translate-x-0' : '-translate-x-full'
                }`}
            >
                <div className="p-6">
                    <h1 className="text-2xl font-bold mb-8 text-white">Skills Dashboard</h1>
                    <nav>
                        <ul className="space-y-2">
                            <li>
                                <button
                                    onClick={() => handlePageNavigation('Home')}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-gray-800 transition-colors ${currentPage === 'Home' ? 'bg-gray-800' : ''} ${!profileComplete ? 'opacity-50' : ''}`}
                                >
                                    <Home className="mr-3" size={20} />
                                    <span>Home</span>
                                </button>
                            </li>
                            <li>
                                <button
                                    onClick={() => handlePageNavigation('Skills')}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-gray-800 transition-colors ${currentPage === 'Skills' ? 'bg-gray-800' : ''} ${!profileComplete ? 'opacity-50' : ''}`}
                                >
                                    <BookOpen className="mr-3" size={20} />
                                    <span>Skills</span>
                                </button>
                            </li>
                            <li>
                                <button
                                    onClick={() => handlePageNavigation('Profile')}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-gray-800 transition-colors ${currentPage === 'Profile' ? 'bg-gray-800' : ''}`}
                                >
                                    <Settings className="mr-3" size={20} />
                                    <span>Profile</span>
                                    {!profileComplete && (
                                        <span className="ml-auto bg-rose-500 text-white text-xs px-2 py-1 rounded-full">Required</span>
                                    )}
                                </button>
                            </li>
                        </ul>
                    </nav>
                </div>
            </aside>

            {/* Main content */}
            <div className="flex flex-col flex-1 md:ml-64">
                {/* Header */}
                <header className="bg-white shadow-sm h-16 flex items-center px-6 border-b border-slate-200">
                    <h2 className="text-lg font-semibold text-indigo-900 ml-8 md:ml-0">{currentPage}</h2>
                    <div className="ml-auto relative">
                        <button
                            onClick={() => setProfileOpen(!profileOpen)}
                            className="flex items-center focus:outline-none"
                        >
                            <div className="h-10 w-10 bg-indigo-100 rounded-full flex items-center justify-center text-indigo-700 overflow-hidden">
                                {userProfile.profilePhoto ? (
                                    <img src={userProfile.profilePhoto} alt="Profile" className="h-full w-full object-cover" />
                                ) : (
                                    <User size={20} />
                                )}
                            </div>
                            <ChevronDown size={16} className="ml-2 text-slate-500" />
                        </button>

                        {/* Profile dropdown */}
                        {profileOpen && (
                            <div className="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg z-20 border border-slate-200">
                                <div className="py-1">
                                    <button
                                        onClick={() => handlePageNavigation('Profile')}
                                        className="flex items-center px-4 py-2 text-sm text-slate-700 hover:bg-slate-100 w-full text-left transition-colors"
                                    >
                                        <Settings size={16} className="mr-2" />
                                        Profile Settings
                                        {!profileComplete && (
                                            <span className="ml-auto bg-rose-500 text-white text-xs px-1 py-px rounded-full">!</span>
                                        )}
                                    </button>
                                    <button className="flex items-center px-4 py-2 text-sm text-slate-700 hover:bg-slate-100 w-full text-left transition-colors">
                                        <LogOut size={16} className="mr-2" />
                                        Sign Out
                                    </button>
                                </div>
                            </div>
                        )}
                    </div>
                </header>

                {/* Main content area */}
                <main className="flex-1 p-6 bg-slate-50 overflow-y-auto">
                    {currentPage === 'Skills' && (
                        <div className="bg-white rounded-lg shadow-md p-6 border border-slate-200">
                            <h3 className="text-xl font-semibold mb-6 text-indigo-800">My Skills</h3>

                            {/* Add new skill form */}
                            <div className="mb-8 bg-indigo-50 p-5 rounded-lg border border-indigo-100">
                                <h4 className="font-medium text-indigo-800 mb-3">Add New Skill</h4>
                                <div className="flex flex-col md:flex-row gap-4">
                                    <div className="flex-1">
                                        <input
                                            type="text"
                                            placeholder="Enter skill name"
                                            className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
                                            value={newSkill}
                                            onChange={(e) => setNewSkill(e.target.value)}
                                            list="skill-suggestions"
                                        />
                                        <datalist id="skill-suggestions">
                                            {skillSuggestions.map(suggestion => (
                                                <option key={suggestion} value={suggestion} />
                                            ))}
                                        </datalist>
                                    </div>
                                    <select
                                        className="p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
                                        value={newLevel}
                                        onChange={(e) => setNewLevel(e.target.value)}
                                    >
                                        <option value="Beginner">Beginner</option>
                                        <option value="Intermediate">Intermediate</option>
                                        <option value="Advanced">Advanced</option>
                                        <option value="Expert">Expert</option>
                                    </select>
                                    <button
                                        onClick={handleAddSkill}
                                        className="bg-indigo-600 text-white p-2 rounded-md flex items-center justify-center hover:bg-indigo-700 transition-colors"
                                    >
                                        <PlusCircle size={16} className="mr-2" />
                                        Add Skill
                                    </button>
                                </div>
                            </div>

                            {/* Skills list */}
                            <div className="overflow-x-auto">
                                <table className="min-w-full divide-y divide-slate-200">
                                    <thead className="bg-slate-50">
                                        <tr>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-slate-500 uppercase tracking-wider">Skill</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-slate-500 uppercase tracking-wider">Level</th>
                                            <th className="px-6 py-3 text-right text-xs font-medium text-slate-500 uppercase tracking-wider">Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody className="bg-white divide-y divide-slate-200">
                                        {skills.map(skill => (
                                            <tr key={skill.id} className="hover:bg-slate-50 transition-colors">
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    {editingId === skill.id ? (
                                                        <input
                                                            type="text"
                                                            className="w-full p-1 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
                                                            value={editSkill}
                                                            onChange={(e) => setEditSkill(e.target.value)}
                                                        />
                                                    ) : (
                                                        <div className="text-sm font-medium text-slate-900">{skill.name}</div>
                                                    )}
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    {editingId === skill.id ? (
                                                        <select
                                                            className="p-1 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500"
                                                            value={editLevel}
                                                            onChange={(e) => setEditLevel(e.target.value)}
                                                        >
                                                            <option value="Beginner">Beginner</option>
                                                            <option value="Intermediate">Intermediate</option>
                                                            <option value="Advanced">Advanced</option>
                                                            <option value="Expert">Expert</option>
                                                        </select>
                                                    ) : (
                                                        <span className={`px-3 py-1 inline-flex text-xs leading-5 font-semibold rounded-full 
                                                        ${skill.level === 'Beginner' ? 'bg-slate-100 text-slate-800' : ''}
                                                        ${skill.level === 'Intermediate' ? 'bg-indigo-100 text-indigo-800' : ''}
                                                        ${skill.level === 'Advanced' ? 'bg-emerald-100 text-emerald-800' : ''}
                                                        ${skill.level === 'Expert' ? 'bg-violet-100 text-violet-800' : ''}
                                                        `}>
                                                            {skill.level}
                                                        </span>
                                                    )}
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                                                    {editingId === skill.id ? (
                                                        <button
                                                            onClick={saveEdit}
                                                            className="text-emerald-600 hover:text-emerald-800 mr-3 transition-colors"
                                                        >
                                                            Save
                                                        </button>
                                                    ) : (
                                                        <button
                                                            onClick={() => startEditing(skill)}
                                                            className="text-indigo-600 hover:text-indigo-800 mr-3 transition-colors"
                                                        >
                                                            <Edit2 size={16} />
                                                        </button>
                                                    )}
                                                    <button
                                                        onClick={() => handleDeleteSkill(skill.id)}
                                                        className="text-rose-600 hover:text-rose-800 transition-colors"
                                                    >
                                                        <Trash2 size={16} />
                                                    </button>
                                                </td>
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    )}

                    {currentPage === 'Home' && (
                        <div className="bg-white rounded-lg shadow-md p-6 border border-slate-200">
                            <h3 className="text-xl font-semibold mb-4 text-indigo-800">Welcome to Your Skills Dashboard</h3>
                            <p className="text-slate-600">
                                Track and manage your professional skills. Use the Skills page to add new skills,
                                assess your proficiency level, and keep your skill set up to date.
                            </p>
                            <div className="mt-6 p-4 bg-indigo-50 rounded-lg border border-indigo-100">
                                <p className="text-sm text-indigo-700">
                                    You currently have <span className="font-bold">{skills.length}</span> skills in your profile.
                                </p>
                            </div>
                        </div>
                    )}

                    {/* Profile Settings Section */}
                    {currentPage === 'Profile' && (
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
                                    {/* Username */}
                                    <div>
                                        <label htmlFor="userName" className="block text-sm font-medium text-slate-700 mb-1">
                                            Username <span className="text-rose-500">*</span>
                                        </label>
                                        <input
                                            type="text"
                                            id="userName"
                                            name="userName"
                                            value={userProfile.userName}
                                            onChange={handleProfileChange}
                                            required
                                            className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
                                        />
                                    </div>

                                    {/* Email */}
                                    <div>
                                        <label htmlFor="email" className="block text-sm font-medium text-slate-700 mb-1">
                                            Email <span className="text-rose-500">*</span>
                                        </label>
                                        <input
                                            type="email"
                                            id="email"
                                            name="email"
                                            value={userProfile.email}
                                            onChange={handleProfileChange}
                                            required
                                            className="w-full p-2 border border-slate-300 rounded-md focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:border-indigo-500"
                                        />
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
                                    >
                                        Save Profile
                                    </button>
                                    {!profileComplete && (
                                        <p className="mt-2 text-sm text-rose-600">* Required fields must be completed</p>
                                    )}
                                </div>
                            </form>
                        </div>
                    )}
                </main>
            </div>
        </div>
    );
};

export default SkillDashboard;