using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillGapDTO;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppSkillGapService: ApplicationService
    {
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly ISkillSubtopicRepository _skillSubtopicRepository;

        public AppSkillGapService(IEmployeeSkillRepository employeeSkillRepository, ISkillSubtopicRepository skillSubtopicRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
            _skillSubtopicRepository = skillSubtopicRepository;
        }

        public async Task<ServiceResponse<SkillGapResponseDto>> GetSkillGapsAsync(Guid userId)
        {
            var employeeDetails = (await _employeeSkillRepository.GetAllAsync())
                .Where(u => u.UserId == userId).ToList();

            var employeeSkills = employeeDetails
                .Select(u => u.CoreSkillName)
                .ToList();

            var employeeProficiency = employeeDetails
                .Select(u => u.SelfAssessedProficiency.ToString())
                .ToList();

            var departmentSkillDetails = (await _skillSubtopicRepository.GetAllAsync())
                .Select(s => s.Description)
                .ToList();

            var departmentSkills = new List<string>();
            var departmentSkillsProficiency = new List<string>();
            var employeeSkillsSet = new HashSet<string>();

            foreach (var skills in departmentSkillDetails)
            {
                if (skills == null) continue;
                foreach (var kvp in skills)
                {
                    if (employeeSkills.Contains(kvp.Key) && employeeSkillsSet.Add(kvp.Key))
                    {
                        departmentSkills.Add(kvp.Key);
                        departmentSkillsProficiency.Add(kvp.Value);
                    }
                }
            }

            var skillGapResponseDto = new SkillGapResponseDto()
            {
                Skills = employeeSkills,
                EmployeeProficiency = employeeProficiency,
                DepartmentRequiredProficiency = departmentSkillsProficiency
            };
            return ServiceResponse<SkillGapResponseDto>.SuccessResult(skillGapResponseDto, 200);
        }
    }
}
