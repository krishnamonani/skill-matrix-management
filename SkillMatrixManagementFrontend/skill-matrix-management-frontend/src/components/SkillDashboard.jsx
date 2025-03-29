import React, { useState } from 'react';
import { User, Home, BookOpen, Settings, LogOut, Edit2, Trash2, PlusCircle, ChevronDown } from 'lucide-react';

const SkillDashboard = () => {
    const [sidebarOpen, setSidebarOpen] = useState(false);
    const [profileOpen, setProfileOpen] = useState(false);
    const [skills, setSkills] = useState([
        { id: 1, name: 'React', level: 'Advanced' },
        { id: 2, name: 'TypeScript', level: 'Intermediate' },
        { id: 3, name: 'Tailwind CSS', level: 'Expert' },
    ]);
    const [currentPage, setCurrentPage] = useState('Skills');
    const [newSkill, setNewSkill] = useState('');
    const [newLevel, setNewLevel] = useState('Beginner');
    const [editingId, setEditingId] = useState(null);
    const [editSkill, setEditSkill] = useState('');
    const [editLevel, setEditLevel] = useState('');

    const skillSuggestions = ['JavaScript', 'HTML', 'CSS', 'Node.js', 'Next.js', 'Vue.js', 'Angular', 'Python', 'Java'];

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

    return (
        <div className="flex h-screen bg-gray-50">
            {/* Mobile sidebar toggle */}
            <button
                className="p-2 rounded-md md:hidden fixed top-4 left-4 z-20 bg-blue-600 text-white"
                onClick={() => setSidebarOpen(!sidebarOpen)}
            >
                <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4 6h16M4 12h16M4 18h16" />
                </svg>
            </button>

            {/* Sidebar */}
            <aside
                className={`bg-blue-700 text-white w-64 flex-shrink-0 fixed inset-y-0 left-0 transform transition-transform duration-300 ease-in-out z-10 md:translate-x-0 ${sidebarOpen ? 'translate-x-0' : '-translate-x-full'
                    }`}
            >
                <div className="p-6">
                    <h1 className="text-2xl font-bold mb-8">Skills Dashboard</h1>
                    <nav>
                        <ul className="space-y-2">
                            <li>
                                <button
                                    onClick={() => { setCurrentPage('Home'); setSidebarOpen(false); }}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-blue-600 ${currentPage === 'Home' ? 'bg-blue-800' : ''}`}
                                >
                                    <Home className="mr-3" size={20} />
                                    <span>Home</span>
                                </button>
                            </li>
                            <li>
                                <button
                                    onClick={() => { setCurrentPage('Skills'); setSidebarOpen(false); }}
                                    className={`flex items-center p-3 w-full text-left rounded-lg hover:bg-blue-600 ${currentPage === 'Skills' ? 'bg-blue-800' : ''}`}
                                >
                                    <BookOpen className="mr-3" size={20} />
                                    <span>Skills</span>
                                </button>
                            </li>
                        </ul>
                    </nav>
                </div>
            </aside>

            {/* Main content */}
            <div className="flex flex-col flex-1 md:ml-64">
                {/* Header */}
                <header className="bg-white shadow-sm h-16 flex items-center px-6">
                    <h2 className="text-lg font-semibold text-gray-800 ml-8 md:ml-0">{currentPage}</h2>
                    <div className="ml-auto relative">
                        <button
                            onClick={() => setProfileOpen(!profileOpen)}
                            className="flex items-center focus:outline-none"
                        >
                            <div className="h-10 w-10 bg-green-200 rounded-full flex items-center justify-center text-blue-700">
                                <User size={20} />
                            </div>
                            <ChevronDown size={16} className="ml-2 text-gray-600" />
                        </button>

                        {/* Profile dropdown */}
                        {profileOpen && (
                            <div className="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg z-20">
                                <div className="py-1">
                                    <button className="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left">
                                        <Settings size={16} className="mr-2" />
                                        Profile Settings
                                    </button>
                                    <button className="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left">
                                        <LogOut size={16} className="mr-2" />
                                        Sign Out
                                    </button>
                                </div>
                            </div>
                        )}
                    </div>
                </header>

                {/* Main content area */}
                <main className="flex-1 p-6">
                    {currentPage === 'Skills' && (
                        <div className="bg-white rounded-lg shadow p-6">
                            <h3 className="text-xl font-semibold mb-6 text-blue-800">My Skills</h3>

                            {/* Add new skill form */}
                            <div className="mb-8 bg-green-50 p-4 rounded-lg">
                                <h4 className="font-medium text-blue-800 mb-3">Add New Skill</h4>
                                <div className="flex flex-col md:flex-row gap-4">
                                    <div className="flex-1">
                                        <input
                                            type="text"
                                            placeholder="Enter skill name"
                                            className="w-full p-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
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
                                        className="p-2 border border-gray-300 rounded focus:outline-none focus:ring-2 focus:ring-blue-500"
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
                                        className="bg-blue-600 text-white p-2 rounded flex items-center justify-center hover:bg-blue-700"
                                    >
                                        <PlusCircle size={16} className="mr-2" />
                                        Add Skill
                                    </button>
                                </div>
                            </div>

                            {/* Skills list */}
                            <div className="overflow-x-auto">
                                <table className="min-w-full divide-y divide-gray-200">
                                    <thead className="bg-gray-50">
                                        <tr>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Skill</th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Level</th>
                                            <th className="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody className="bg-white divide-y divide-gray-200">
                                        {skills.map(skill => (
                                            <tr key={skill.id}>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    {editingId === skill.id ? (
                                                        <input
                                                            type="text"
                                                            className="w-full p-1 border border-gray-300 rounded"
                                                            value={editSkill}
                                                            onChange={(e) => setEditSkill(e.target.value)}
                                                        />
                                                    ) : (
                                                        <div className="text-sm font-medium text-gray-900">{skill.name}</div>
                                                    )}
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    {editingId === skill.id ? (
                                                        <select
                                                            className="p-1 border border-gray-300 rounded"
                                                            value={editLevel}
                                                            onChange={(e) => setEditLevel(e.target.value)}
                                                        >
                                                            <option value="Beginner">Beginner</option>
                                                            <option value="Intermediate">Intermediate</option>
                                                            <option value="Advanced">Advanced</option>
                                                            <option value="Expert">Expert</option>
                                                        </select>
                                                    ) : (
                                                        <span className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full 
                              ${skill.level === 'Beginner' ? 'bg-gray-100 text-gray-800' : ''}
                              ${skill.level === 'Intermediate' ? 'bg-blue-100 text-blue-800' : ''}
                              ${skill.level === 'Advanced' ? 'bg-green-100 text-green-800' : ''}
                              ${skill.level === 'Expert' ? 'bg-purple-100 text-purple-800' : ''}
                            `}>
                                                            {skill.level}
                                                        </span>
                                                    )}
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                                                    {editingId === skill.id ? (
                                                        <button
                                                            onClick={saveEdit}
                                                            className="text-green-600 hover:text-green-900 mr-3"
                                                        >
                                                            Save
                                                        </button>
                                                    ) : (
                                                        <button
                                                            onClick={() => startEditing(skill)}
                                                            className="text-blue-600 hover:text-blue-900 mr-3"
                                                        >
                                                            <Edit2 size={16} />
                                                        </button>
                                                    )}
                                                    <button
                                                        onClick={() => handleDeleteSkill(skill.id)}
                                                        className="text-red-600 hover:text-red-900"
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
                        <div className="bg-white rounded-lg shadow p-6">
                            <h3 className="text-xl font-semibold mb-4 text-blue-800">Welcome to Your Skills Dashboard</h3>
                            <p className="text-gray-600">
                                Track and manage your professional skills. Use the Skills page to add new skills,
                                assess your proficiency level, and keep your skill set up to date.
                            </p>
                            <div className="mt-6 p-4 bg-blue-50 rounded-lg">
                                <p className="text-sm text-blue-700">
                                    You currently have <span className="font-bold">{skills.length}</span> skills in your profile.
                                </p>
                            </div>
                        </div>
                    )}
                </main>
            </div>
        </div>
    );
};

export default SkillDashboard;