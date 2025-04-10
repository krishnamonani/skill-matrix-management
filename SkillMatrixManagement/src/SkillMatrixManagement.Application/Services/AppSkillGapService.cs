using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillGapDTO;
using SkillMatrixManagement.Models;
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
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly ISkillSubtopicRepository _skillSubtopicRepository;

        public AppSkillGapService(IEmployeeSkillRepository employeeSkillRepository, 
                                  ISkillSubtopicRepository skillSubtopicRepository,
                                  IUserRepository userRepository,
                                  ISkillRepository skillRepository)
        {
            _employeeSkillRepository = employeeSkillRepository;
            _skillSubtopicRepository = skillSubtopicRepository;
            _userRepository = userRepository;
            _skillRepository = skillRepository;
        }

        public async Task<ServiceResponse<SkillGapResponseDto>> GetSkillGapsAsync(Guid userId)
        {
            try
            {
                // retrieving the employee detials
                var employee = await _userRepository.GetByIdAsync(userId);
                var employeeInternalRoleId = employee.SkillId;

                // retrieving the employee skill details
                var employeeDetails = (await _employeeSkillRepository.GetAllAsync())
                    .Where(u => u.UserId == userId).ToList();

                var employeeSkills = employeeDetails
                    .Select(u => u.CoreSkillName)
                    .ToList();

                var employeeProficiency = employeeDetails
                    .Select(u => u.SelfAssessedProficiency.ToString())
                    .ToList();

                // retrieving based on employee internal role
                var skillsBasedOnEmployeeInternalRole = (await _skillRepository.GetAllAsync()).Where(skill => skill.InternalRoleId == employeeInternalRoleId).ToList();
                var skillSubtopicBasedOnEmployeeSkills = new List<SkillSubtopic>();

                foreach (var skill in skillsBasedOnEmployeeInternalRole)
                {
                    var skillSubtopicList = (await _skillSubtopicRepository.GetAllAsync()).Where(sst => sst.SkillId == skill.Id);
                    skillSubtopicBasedOnEmployeeSkills.AddRange(skillSubtopicList);
                }

                var employeeBasedSkillDetailsDesctiption = skillSubtopicBasedOnEmployeeSkills.Select(s => s.Description).ToList();

                var departmentSkills = new List<string>();
                var departmentSkillsProficiency = new List<string>();
                var employeeSkillsSet = new HashSet<string>();


                foreach (var empSkill in employeeSkills)
                {
                    if (empSkill == null) continue;
                    var isSkillFound = false;
                    foreach (var skills in employeeBasedSkillDetailsDesctiption)
                    {
                        if (skills == null) continue;
                        foreach (var kvp in skills)
                        {
                            if (empSkill == kvp.Key && !isSkillFound)
                            {
                                departmentSkillsProficiency.Add(kvp.Value);
                                isSkillFound = true;
                                break;
                            }
                        }
                    }
                    if (!isSkillFound) departmentSkillsProficiency.Add("");
                }

                var skillGapResponseDto = new SkillGapResponseDto()
                {
                    Skills = employeeSkills,
                    EmployeeProficiency = employeeProficiency,
                    DepartmentRequiredProficiency = departmentSkillsProficiency
                };
                return ServiceResponse<SkillGapResponseDto>.SuccessResult(skillGapResponseDto, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillGapResponseDto>.Failure(ex.Message, 400);
            }            
        }
    }
}
