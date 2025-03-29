import React, { useState } from 'react';

const AdminDashboard = () => {
  const [employees, setEmployees] = useState([
    {
      id: 1,
      name: 'Dharmi Javiya',
      email: 'dharmi@gmail.com',
      role: 'Software Developer I',
      proficiency: 'Beginner',
      department: 'Tech',
      skills: [{ name: 'React', level: 'Intermediate' }],
    },
  ]);
  const [newEmployee, setNewEmployee] = useState({ name: '', email: '', role: '', proficiency: '', department: '', skills: [] });
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [editingEmployee, setEditingEmployee] = useState(null);
  const [viewingEmployee, setViewingEmployee] = useState(null);
  const [newSkill, setNewSkill] = useState({ name: '', level: 'Beginner' });
  const [searchTerm, setSearchTerm] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const [isProfileOpen, setIsProfileOpen] = useState(false);
  const [profileOpen, setProfileOpen] = useState(false);
  const itemsPerPage = 5;

  const handleAddEmployee = () => {
    const id = employees.length > 0 ? Math.max(...employees.map(emp => emp.id)) + 1 : 1;
    setEmployees([...employees, { ...newEmployee, id }]);
    setNewEmployee({ name: '', email: '', role: '', proficiency: '', department: '', skills: [] });
    setIsAddModalOpen(false);
  };

  const handleEditEmployee = () => {
    setEmployees(employees.map(emp => (emp.id === editingEmployee.id ? editingEmployee : emp)));
    setEditingEmployee(null);
  };

  const handleDeleteEmployee = (id) => {
    setEmployees(employees.filter(emp => emp.id !== id));
  };

  const handleAddSkill = () => {
    if (viewingEmployee) {
      const updatedEmployee = {
        ...viewingEmployee,
        skills: [...viewingEmployee.skills, newSkill],
      };
      setEmployees(employees.map(emp => (emp.id === viewingEmployee.id ? updatedEmployee : emp)));
      setViewingEmployee(updatedEmployee);
      setNewSkill({ name: '', level: 'Beginner' });
    }
  };

  const filteredEmployees = employees.filter(emp =>
    emp.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    emp.role.toLowerCase().includes(searchTerm.toLowerCase()) ||
    emp.department.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const totalPages = Math.ceil(filteredEmployees.length / itemsPerPage);
  const paginatedEmployees = filteredEmployees.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage);

  return (
    <div className="flex flex-col h-screen bg-gray-100">
      {/* Header */}
      <header className="bg-white shadow-md p-4 flex justify-between items-center">
        <h1 className="text-2xl font-bold text-blue-600">Skill Matrix</h1>
        <div className="relative">
          <button
            onClick={() => setProfileOpen(!profileOpen)}
            className="flex items-center focus:outline-none"
          >
            <div className="h-10 w-10 bg-gray-300 rounded-full flex items-center justify-center text-gray-700">
              A
            </div>
            <span className="ml-2 text-gray-700 font-medium">Admin</span>
          </button>

          {/* Profile dropdown */}
          {profileOpen && (
            <div className="absolute right-0 mt-2 w-48 bg-white rounded-md shadow-lg z-20 border border-gray-200">
              <div className="py-1">
                <button className="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left transition-colors">
                  Profile Settings
                </button>
                <button
                  onClick={() => alert('Signing out...')}
                  className="flex items-center px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left transition-colors"
                >
                  Sign Out
                </button>
              </div>
            </div>
          )}
        </div>
      </header>

      {/* Sidebar and Main Content */}
      <div className="flex flex-1">
        {/* Sidebar */}
        <aside className="w-64 bg-gray-700 text-white p-4">

          <h2 className="text-lg font-semibold mb-4">Employees</h2>
        </aside>

        {/* Main Content */}
        <main className="flex-1 p-6">
          <div className="bg-white shadow-md rounded-lg p-4">
            <div className="flex justify-between items-center mb-4">
              <h2 className="text-lg font-semibold text-gray-700">Employees Details</h2>
              <button
                onClick={() => setIsAddModalOpen(true)}
                className="bg-blue-600 text-white px-4 py-2 rounded-md"
              >
                Add Employee
              </button>
            </div>

            {/* Search Bar */}
            <div className="mb-4">
              <input
                type="text"
                placeholder="Search by name, role, or department"
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="w-full p-2 border border-gray-300 rounded-md"
              />
            </div>

            {/* Employee Table */}
            <table className="w-full border-collapse border border-gray-300">
              <thead className="bg-gray-100">
                <tr>
                  <th className="border border-gray-300 p-2 text-left">Employee</th>
                  <th className="border border-gray-300 p-2 text-left">Email</th>
                  <th className="border border-gray-300 p-2 text-left">Role</th>
                  <th className="border border-gray-300 p-2 text-left">Proficiency</th>
                  <th className="border border-gray-300 p-2 text-left">Department</th>
                  <th className="border border-gray-300 p-2 text-left">Skills</th>
                  <th className="border border-gray-300 p-2 text-center">Actions</th>
                </tr>
              </thead>
              <tbody>
                {paginatedEmployees.map(emp => (
                  <tr key={emp.id} className="hover:bg-gray-50">
                    <td className="border border-gray-300 p-2">{emp.name}</td>
                    <td className="border border-gray-300 p-2">{emp.email}</td>
                    <td className="border border-gray-300 p-2">{emp.role}</td>
                    <td className="border border-gray-300 p-2">{emp.proficiency}</td>
                    <td className="border border-gray-300 p-2">{emp.department}</td>
                    <td className="border border-gray-300 p-2">
                      {emp.skills.map(skill => skill.name).join(', ')}
                    </td>
                    <td className="border border-gray-300 p-2 text-center">
                      <button
                        onClick={() => setViewingEmployee(emp)}
                        className="bg-blue-500 text-white px-2 py-1 rounded-md mr-2"
                      >
                        View
                      </button>
                      <button
                        onClick={() => setEditingEmployee(emp)}
                        className="bg-yellow-500 text-white px-2 py-1 rounded-md mr-2"
                      >
                        Edit
                      </button>
                      <button
                        onClick={() => handleDeleteEmployee(emp.id)}
                        className="bg-red-500 text-white px-2 py-1 rounded-md"
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>

            {/* Pagination */}
            <div className="flex justify-between items-center mt-4">
              <button
                onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
                disabled={currentPage === 1}
                className="bg-gray-300 text-gray-700 px-4 py-2 rounded-md"
              >
                Previous
              </button>
              <span>
                Page {currentPage} of {totalPages}
              </span>
              <button
                onClick={() => setCurrentPage((prev) => Math.min(prev + 1, totalPages))}
                disabled={currentPage === totalPages}
                className="bg-gray-300 text-gray-700 px-4 py-2 rounded-md"
              >
                Next
              </button>
            </div>
          </div>
        </main>
      </div>

      {/* Admin Profile Modal */}
      {isProfileOpen && (
        <div className="fixed inset-0 bg-gray-100 bg-opacity-90 flex items-center justify-center">
          <div className="bg-white p-6 rounded-lg shadow-lg w-96">
            <h3 className="text-lg font-semibold mb-4">Admin Profile</h3>
            <p><strong>Name:</strong> Admin</p>
            <p><strong>Email:</strong> admin@example.com</p>
            <div className="flex justify-end mt-4">
              <button
                onClick={() => setIsProfileOpen(false)}
                className="bg-gray-500 text-white px-4 py-2 rounded-md"
              >
                Close
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Add Employee Modal */}
      {isAddModalOpen && (
        <div className="fixed inset-0 bg-gray-100 bg-opacity-90 flex items-center justify-center">
          <div className="bg-white p-6 rounded-lg shadow-lg w-96">
            <h3 className="text-lg font-semibold mb-4">Add Employee</h3>
            <input
              type="text"
              placeholder="Name"
              value={newEmployee.name}
              onChange={(e) => setNewEmployee({ ...newEmployee, name: e.target.value })}
              className="w-full p-2 border border-gray-300 rounded-md mb-2"
            />
            <input
              type="email"
              placeholder="Email"
              value={newEmployee.email}
              onChange={(e) => setNewEmployee({ ...newEmployee, email: e.target.value })}
              className="w-full p-2 border border-gray-300 rounded-md mb-2"
            />
            <input
              type="text"
              placeholder="Role"
              value={newEmployee.role}
              onChange={(e) => setNewEmployee({ ...newEmployee, role: e.target.value })}
              className="w-full p-2 border border-gray-300 rounded-md mb-2"
            />
            <select
              value={newEmployee.proficiency}
              onChange={(e) => setNewEmployee({ ...newEmployee, proficiency: e.target.value })}
              className="w-full p-2 border border-gray-300 rounded-md mb-2"
            >
              <option value="">Select Proficiency</option>
              <option value="Beginner">Beginner</option>
              <option value="Intermediate">Intermediate</option>
              <option value="Expert">Expert</option>
            </select>
            <input
              type="text"
              placeholder="Department"
              value={newEmployee.department}
              onChange={(e) => setNewEmployee({ ...newEmployee, department: e.target.value })}
              className="w-full p-2 border border-gray-300 rounded-md mb-4"
            />
            <div className="flex justify-end">
              <button
                onClick={handleAddEmployee}
                className="bg-blue-600 text-white px-4 py-2 rounded-md mr-2"
              >
                Add
              </button>
              <button
                onClick={() => setIsAddModalOpen(false)}
                className="bg-gray-500 text-white px-4 py-2 rounded-md"
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default AdminDashboard;