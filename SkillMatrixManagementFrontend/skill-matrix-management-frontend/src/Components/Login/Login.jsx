import React from 'react'

function Login() {
  return (
    <div className='flex-col bg-gray-200'>
     <div className= 'bg-white'> 
      <div className='flex justify-end'> 
      <div className='pl-5 mr-10'>Login</div>
      <div className='pl-5 pr-5 mr-20  bg-blue-300 rounded-lg'>Signup</div>
      </div>
     </div>
     <div >
      <div className='flex ml-40'>
      <div className='bg-red-200'>
        <img src='src\Components\Login\image.jpg' className='w-[400px] h-auto'></img>
      </div>
      <div className='bg-blue-200'>
        <h1>Welcome to Skill Matrix!</h1>
        <p>Unlock opportunities by managing and showcasing
        your skills</p>
        <div>
        <input type='text' placeholder='Enter your first input' className='border rounded p-2 mb-2' />
        </div>
        <div>
        <input type='text' placeholder='Enter your first input' className='border rounded p-2 mb-2' />
        </div>
        <div>
        <input type='text' placeholder='Enter your first input' className='border rounded p-2 mb-2' />
        </div>
        
       

      </div>
      </div>

     </div>

    </div>
  )
}

export default Login
