using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.Services
{
    public interface IXLSXService
    {
        Task<(MemoryStream, string)> GenerateAllEmployeesExcelAsync();
        Task<(MemoryStream, string)> GenerateProjectEmployeesExcelAsync(Guid projectId);
        Task<(MemoryStream, string)> GenerateEmployeeExcelAsync(Guid userId);
    }
}
