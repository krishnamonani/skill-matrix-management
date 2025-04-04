using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SkillMatrixManagement.DTOs.AiSkillRecommendationDTO;
using SkillMatrixManagement.DTOs.AiTeamRecommendationDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using SkillMatrixManagement.Services;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace SkillMatrixManagement.AiServices
{
    public class AppAiRecommendationService: ApplicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentInternalRoleRepository _departmentInternalRoleRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly string RECOMMENDATION_END_POINT;

        public AppAiRecommendationService(IHttpClientFactory httpClientFactory, 
                                          IUserRepository userRepository, 
                                          IDepartmentInternalRoleRepository departmentInternalRoleRepository, 
                                          IEmployeeSkillRepository employeeSkillRepository, 
                                          IDepartmentRepository departmentRepository,
                                          IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _departmentInternalRoleRepository = departmentInternalRoleRepository;
            _userRepository = userRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _departmentRepository = departmentRepository;
            RECOMMENDATION_END_POINT = configuration["AiServices:SkillRecommendationEndPoint"] ?? throw new ArgumentNullException(nameof(configuration), "Recommendation end point is not configured in appsettings.json");
        }

        public async Task<ServiceResponse<SkillRecommendationResponseDto>> GetSkillRecommendation(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null) throw new Exception("User Not Found!");

                Guid? departmentInternalRoleId = user.InternalRoleId;

                var departmentInternalRoleName = "General role";
                if (departmentInternalRoleId != null)
                {
                    var departmentInternalRole = await _departmentInternalRoleRepository.GetByIdAsync(departmentInternalRoleId ?? throw new Exception("Department Role not found!"));
                    if (departmentInternalRole == null) throw new Exception("Department Role not found!");
                    departmentInternalRoleName = departmentInternalRole.RoleName.ToString();
                }                

                var employeeSkills = await _employeeSkillRepository.GetAllAsync();
                var reqEmployeeSkills = employeeSkills.Where(e => e.UserId == userId);

                var skills = new List<string>();
                foreach(var skill in reqEmployeeSkills)
                {
                    skills.Add(skill.CoreSkillName);
                }

                var client = _httpClientFactory.CreateClient();

                // Define the request body
                var requestBody = new SkillRecommendationInputDto()
                {
                    Role = departmentInternalRoleName,
                    Skills = skills.Count() != 0 ? skills : new List<string>()
                };

                // Serialize to JSON
                string jsonBody = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(RECOMMENDATION_END_POINT, content);
                response.EnsureSuccessStatusCode();

                // Return response as string
                var responseBody = await response.Content.ReadAsStringAsync();
                var recommendationData = JsonSerializer.Deserialize<SkillRecommendationResponseDto>(responseBody);

                return ServiceResponse<SkillRecommendationResponseDto>.SuccessResult(recommendationData ?? new SkillRecommendationResponseDto(), 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillRecommendationResponseDto>.Failure(ex.Message, 500);
            }
        }

        public async Task<ServiceResponse<ICollection<EmployeeDetailDto>>> GetTeamRecommendationAsync(string projectDescription)
        {
            return ServiceResponse<ICollection<EmployeeDetailDto>>.SuccessResult((await GetEmployeeDetails()), 200);
        }

        //public ServiceResponse GetTeamRecommendationAsync(IRemoteStreamContent file)
        //{
        //    return ServiceResponse.SuccessResult(200, "Team recommendation from file stream");
        //}


        private async Task<ICollection<EmployeeDetailDto>> GetEmployeeDetails()
        {

            // fetching all the db details here
            var users = await _userRepository.GetAllAsync();
            var employeeSkills = await _employeeSkillRepository.GetAllAsync();
            var departments = await _departmentRepository.GetAllAsync();
            var departmentInternalRoles = await _departmentInternalRoleRepository.GetAllAsync();

            // init the Dto object
            var employeeDetailsList = new List<EmployeeDetailDto>();
            foreach(var user in users)
            {
                var department = departments.Where(dept => dept.Id == user.DepartmentId).FirstOrDefault() ?? null;
                var internalRole = departmentInternalRoles.Where(irole => irole.Id == user.InternalRoleId).FirstOrDefault() ?? null;

                string? departmentName = null;
                string? internalRoleName = null;

                if (department != null) departmentName = department.Name;
                if (internalRole != null) internalRoleName = internalRole.RoleName.ToString();

                var skills = new List<Dictionary<string, string>>();

                var skillList = employeeSkills.Where(eskill => eskill.UserId == user.Id).Select(s => s.CoreSkillName).ToList();
                var proficiencyList = employeeSkills.Where(eskill => eskill.UserId == user.Id).Select(s => s.SelfAssessedProficiency.ToString()).ToList();

                if (skillList.Count != proficiencyList.Count) continue;
                int index = 0;
                foreach(var skill in skillList)
                {
                    var dictionary = new Dictionary<string, string>();
                    dictionary.Add(skill, proficiencyList[index++]);
                    skills.Add(dictionary);
                }

                employeeDetailsList.Add(
                       new EmployeeDetailDto()
                       {
                           Id = user.Id,
                           FirstName = user.FirstName,
                           LastName = user.LastName,
                           UserName = user.UserName,
                           Email = user.Email,
                           Experience = user.Experience,
                           Department = departmentName,
                           Designation = internalRoleName,
                           Skills = skills,
                           ProjectStatus = user.IsAvailable.ToString()
                       }
                    );
            }

            return employeeDetailsList;
        }
    }
}
