import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import SkillTable from "./components/SkillTable";

function App() {
  return (
    <Router>
      <div className="flex h-screen">
        {/* Sidebar */}
        <Sidebar />

        {/* Main Content */}
        <div className="flex-1 flex flex-col bg-gray-100">
          <Header />
          <main className="flex-1 p-6 overflow-auto">
            <Routes>
              <Route
                path="/"
                element={<h2 className="text-2xl font-semibold">🏠 Welcome to the Home Page</h2>}
              />
              <Route path="/skills" element={<SkillTable />} />
              
            </Routes>
          </main>
        </div>
      </div>
    </Router>
  );
}

export default App;
