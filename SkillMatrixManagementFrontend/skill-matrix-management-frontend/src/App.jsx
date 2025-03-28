import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Recommendskill from './Components/Recommendskill';
function App() {
  const [count, setCount] = useState(0)

  return (
    <div className='p-0 m-0'>
      <>
       <Recommendskill/>
    </>
    </div>
  )
}

export default App
