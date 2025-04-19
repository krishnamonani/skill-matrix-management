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
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

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
                var employeeSkillId = employee.SkillId;

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
                var skillsBasedOnEmployeeInternalRole = (await _skillRepository.GetAllAsync()).Where(skill => skill.Id == employeeSkillId).ToList();
                var skillSubtopicBasedOnEmployeeSkills = new List<SkillSubtopic>();

                foreach (var skill in skillsBasedOnEmployeeInternalRole)
                {
                    var skillSubtopicList = (await _skillSubtopicRepository.GetAllAsync()).Where(sst => sst.SkillId == skill.Id);
                    skillSubtopicBasedOnEmployeeSkills.AddRange(skillSubtopicList);
                }

                var employeeBasedSkillDetailsDesctiption = skillSubtopicBasedOnEmployeeSkills.Select(s => s.Description).ToList();

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

        public async Task<ServiceResponse<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto>> GetCoreSkillGapAnalysisAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);

                if (user == null) throw new Exception("User not found!");
                var employeeSkills = (await _employeeSkillRepository.GetAllAsync())
                    .Where(es => es.UserId == userId)
                    .Select(es => es.CoreSkillName)
                    .ToList();

                var skillSubtopis = (await _skillSubtopicRepository.GetAllAsync())
                    .Where(sst => sst.SkillId == user.SkillId);

                var skillSubtopicsDescriptions = skillSubtopis
                    .Select(sst => sst.Description)
                    .ToList();

                var departmentSkillNames = skillSubtopis
                    .Select(sst => sst.Name)
                    .ToList();

                var departmentCoreSkillNames = new List<List<string>>();

                foreach (var coreSkills in skillSubtopicsDescriptions)
                {
                    if (coreSkills == null) continue;
                    var departmentCoreSkills = new List<string>();
                    foreach (var kvp in coreSkills)
                    {
                        departmentCoreSkills.Add(kvp.Key);
                    }
                    departmentCoreSkillNames.Add(departmentCoreSkills);
                }

                var coreSkillGap = new SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto()
                {
                    DepartmentSkills = departmentSkillNames,
                    DepartmentCoreSkills = departmentCoreSkillNames,
                    EmployeeCoreSkills = employeeSkills
                };

                return ServiceResponse<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto>.SuccessResult(coreSkillGap, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseDto>.Failure(ex.Message, 400);
            }
        }

        public async Task<ServiceResponse<ICollection<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto>>> GetAllUsersCoreSkillGapAnalysisAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                if(users == null) throw new Exception("Users not found!");

                var employeeSkills = await _employeeSkillRepository.GetAllAsync();
                var skillSubtopis = await _skillSubtopicRepository.GetAllAsync();

                var skillSuggestionsBasedOnDepartmentCurrentSkillResponseDtos = new List<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto>();
                foreach (var user in users)
                {
                    var userEmployeeSkills = employeeSkills
                        .Where(es => es.UserId == user.Id)
                        .Select(es => es.CoreSkillName)
                        .ToList();

                    var userSkillSubtopis = skillSubtopis
                        .Where(sst => sst.SkillId == user.SkillId);

                    var userSkillSubtopicsDescriptions = userSkillSubtopis
                        .Select(sst => sst.Description)
                        .ToList();

                    var userDepartmentSkillNames = userSkillSubtopis
                        .Select(sst => sst.Name)
                        .ToList();

                    var userDepartmentCoreSkillNames = new List<List<string>>();

                    foreach (var coreSkills in userSkillSubtopicsDescriptions)
                    {
                        if (coreSkills == null) continue;
                        var departmentCoreSkills = new List<string>();
                        foreach (var kvp in coreSkills)
                        {
                            departmentCoreSkills.Add(kvp.Key);
                        }
                        userDepartmentCoreSkillNames.Add(departmentCoreSkills);
                    }

                    var skillSuggestionsBasedOnDepartmentCurrentSkillResponseDto = new SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto()
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        UserEmail = user.Email,
                        DepartmentSkills = userDepartmentSkillNames,
                        DepartmentCoreSkills = userDepartmentCoreSkillNames,
                        EmployeeCoreSkills = userEmployeeSkills
                    };

                    skillSuggestionsBasedOnDepartmentCurrentSkillResponseDtos.Add(skillSuggestionsBasedOnDepartmentCurrentSkillResponseDto);
                }

                return ServiceResponse<ICollection<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto>>.SuccessResult(skillSuggestionsBasedOnDepartmentCurrentSkillResponseDtos, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ICollection<SkillSuggestionsBasedOnDepartmentCurrentSkillResponseWithEmployeeNmaesDto>>.Failure(ex.Message, 400);
            }
        }
    }
}
