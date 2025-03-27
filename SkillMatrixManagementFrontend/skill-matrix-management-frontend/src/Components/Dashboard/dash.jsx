import React from 'react'
import Table from '../Table'
function dash() {
  return (
    <div className='flex-col w-full h-screen bg-gray-200'>
        <div className=' bg-blue-500 '>
         <div className='flex justify-between'>
         <div >Skill Matrix</div>
         <div >Profile</div>
         </div>
        </div>
        <div className='flex'> 
          <div className=' bg-yellow-200 w-[150px] h-[500px]'>skill</div>
          <div className=' p-3 bg-red-200 w-[100%] h-[500px]'>   
            <div className='m-2 bg-green-100'>
            <div className='flex justify-between'>
               <div >Skill Matrix</div>
               <div className='flex'>
                 <div >Profile</div>
                 <div >Profile</div>
              </div>
            </div>
            </div>
            <div className='m-2 bg-purple-100'>
             <>
                    <Table/>
                 </>
            </div>
           </div>
        </div>
    </div>
  )
}

export default dash
