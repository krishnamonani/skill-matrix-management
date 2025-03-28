import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import SkillTable from "./components/SkillTable";

function App() {
  return (
    <Router>
      <div>
        <Header />
        {/* Sidebar */}
        <div className="flex">
          <Sidebar className="flex-1" />

          {/* Main Content */}
          <div className="flex-1  bg-gray-100">
            <main className="flex-1 p-6 overflow-auto">
              <Routes>
                <Route path="/skills" element={<SkillTable />} />
              </Routes>
            </main>
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;
