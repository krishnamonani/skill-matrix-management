import React from 'react'

function Table() {
  return (
    <div>
      <table className="table-auto w-full border-collapse border border-gray-300">
                <thead>
                  <tr className="bg-gray-200">
                    <th className="border border-gray-300 px-4 py-2">Skill</th>
                    <th className="border border-gray-300 px-4 py-2">Level</th>
                    <th className="border border-gray-300 px-4 py-2">Experience</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td className="border border-gray-300 px-4 py-2">React</td>
                    <td className="border border-gray-300 px-4 py-2">Intermediate</td>
                    <td className="border border-gray-300 px-4 py-2">2 years</td>
                  </tr>
                  <tr className="bg-gray-100">
                    <td className="border border-gray-300 px-4 py-2">JavaScript</td>
                    <td className="border border-gray-300 px-4 py-2">Advanced</td>
                    <td className="border border-gray-300 px-4 py-2">3 years</td>
                  </tr>
                  <tr>
                    <td className="border border-gray-300 px-4 py-2">CSS</td>
                    <td className="border border-gray-300 px-4 py-2">Beginner</td>
                    <td className="border border-gray-300 px-4 py-2">1 year</td>
                  </tr>
                </tbody>
              </table>
    </div>
  )
}

export default Table