import React, { useState, useEffect } from 'react';
import { User, Home, BookOpen, Settings, LogOut, Edit2, Trash2, PlusCircle, ChevronDown } from 'lucide-react';
import { useNavigate } from 'react-router-dom';
import ProfileSettings from './ProfileSettings';

const SkillDashboard = () => {
    const [sidebarOpen, setSidebarOpen] = useState(false);
    const [profileOpen, setProfileOpen] = useState(false);
    const [showSignOutConfirm, setShowSignOutConfirm] = useState(false);
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
    const navigate = useNavigate();

    // User profile state
    const [userProfile, setUserProfile] = useState({
        profilePhoto: null
    });

    // Skill options
    const skillSuggestions = ['JavaScript', 'HTML', 'CSS', 'Node.js', 'Next.js', 'Vue.js', 'Angular', 'Python', 'Java'];

    // Check if profile is complete (this would be updated by the ProfileSettings component)
    useEffect(() => {
        // This would be updated by the ProfileSettings component
        // For now, we'll assume it's always complete to enable navigation
        setProfileComplete(true);
    }, []);

    // Function to handle page navigation
    const handlePageNavigation = (page) => {
        setCurrentPage(page);
        setSidebarOpen(false);
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

    // Function to handle sign out
    const handleSignOut = () => {
        setShowSignOutConfirm(true);
        setProfileOpen(false); // Close profile dropdown
    };

    // Function to confirm sign out
    const confirmSignOut = () => {
        // Clear session data
        sessionStorage.clear();
        
        // Clear local storage data related to user profile
        localStorage.removeItem('userProfileData');
        localStorage.removeItem('userName');
        localStorage.removeItem('userEmail');
        
        // Redirect to login page
        navigate('/');
    };

    // Function to cancel sign out
    const cancelSignOut = () => {
        setShowSignOutConfirm(false);
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
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-gray-800 transition-colors ${currentPage === 'Home' ? 'bg-gray-800' : ''}`}
                                >
                                    <Home className="mr-3" size={20} />
                                    <span>Home</span>
                                </button>
                            </li>
                            <li>
                                <button
                                    onClick={() => handlePageNavigation('Skills')}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-gray-800 transition-colors ${currentPage === 'Skills' ? 'bg-gray-800' : ''}`}
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
                                    </button>
                                    <button 
                                        onClick={handleSignOut}
                                        className="flex items-center px-4 py-2 text-sm text-slate-700 hover:bg-slate-100 w-full text-left transition-colors"
                                    >
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

                    {currentPage === 'Profile' && <ProfileSettings />}
                </main>
            </div>

            {/* Sign Out Confirmation Modal */}
            {showSignOutConfirm && (
                <div className="fixed inset-0 bg-black bg-opacity-50 z-50 flex items-center justify-center">
                    <div className="bg-white rounded-lg shadow-xl p-6 max-w-sm w-full mx-4">
                        <h3 className="text-lg font-medium text-slate-900 mb-4">Sign Out</h3>
                        <p className="text-slate-600 mb-6">
                            Are you sure you want to sign out? All session data will be cleared.
                        </p>
                        <div className="flex justify-end space-x-3">
                            <button
                                onClick={cancelSignOut}
                                className="px-4 py-2 border border-slate-300 rounded-md text-slate-700 hover:bg-slate-50 transition-colors"
                            >
                                Cancel
                            </button>
                            <button
                                onClick={confirmSignOut}
                                className="px-4 py-2 bg-indigo-600 border border-indigo-600 rounded-md text-white hover:bg-indigo-700 transition-colors"
                            >
                                Confirm Sign Out
                            </button>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
};

export default SkillDashboard;