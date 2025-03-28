import React from 'react'
import Table from './Table'
function Recommendskill() {
  return (
    <div className='flex-col w-full h-screen bg-gray-200 p-3'>
        <div className=' bg-white rounded-lg p-3 '>
          <div className='flex justify-between'>
            <div >
             <span className='text-blue-500'> Skill</span>  
             <span className='text-green-500'> Matrix</span> 
              </div>
            <div >Profile</div>
          </div>
        </div>
        <div className='flex'> 
          <div className=' bg-white w-[150px] h-[500px] text-blue-500 rounded-lg p-3 m-3'>Skill</div>
          <div className=' bg-white w-[100%] h-[500px] rounded-lg m-3 '>   
        
            <div className=' bg-white p-4 rounded-lg '>
                    <Table/>
                 
            </div>

           </div>
        </div>
    </div>
  )
}

export default Recommendskill
