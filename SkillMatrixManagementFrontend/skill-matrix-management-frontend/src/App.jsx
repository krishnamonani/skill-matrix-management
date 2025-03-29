import AdminDashboard from "./components/adminDashboard"
import SignInPage from "./components/SingInRegister"
import SkillDashboard from "./components/SkillDashboard"
import ProfileSection from "./components/ProfilieSection"
import { BrowserRouter, Routes, Route } from "react-router-dom"


function App() {

  return (
    <BrowserRouter >
      <Routes>
        <Route path="/skillDashboard" element={<SkillDashboard />} />
        <Route path="/profile" element={<ProfileSection />} />
        <Route path="/login" element={<SignInPage />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
