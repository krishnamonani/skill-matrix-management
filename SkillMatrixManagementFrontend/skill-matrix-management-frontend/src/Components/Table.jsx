import React from 'react'
let skils= {
  "recommended_skills": [
    "skill1",
    "skill2",
    "skill3",
    "skill4",
    "skill5"
  ]
}
function Table() {
  return (
    <div>
      <table className="table-auto w-full border-collapse border border-white rounded-lg p-2 " >
      <thead >
          <tr className=" rounded-lg p-2 bg-white-200">
      
                  <div className='bg-white rounded-lg p-2'>
                  <th className=" border border-white px-4 py-2">Skill</th>
                  </div>
         
           
          </tr>
        </thead>
        <tbody>
          {skils.recommended_skills.map((skill, index) => (
            <tr key={index} className={index % 2 === 0 ? 'bg-gray-200' : 'bg-white'}>
              <td className="border border-white px-4 py-2 text-left">{skill}</td>
            </tr>
          ))}
        </tbody>
              </table>
    </div>
  )
}

export default Table
