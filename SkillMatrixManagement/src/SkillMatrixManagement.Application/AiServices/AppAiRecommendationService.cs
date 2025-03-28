using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.AiSkillRecommendationDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Repositories;
using SkillMatrixManagement.Services;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.AiServices
{
    public class AppAiRecommendationService: ApplicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentInternalRoleRepository _departmentInternalRoleRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly string RECOMMENDATION_END_POINT= "http://127.0.0.1:8000/recommend-skills";

        public AppAiRecommendationService(IHttpClientFactory httpClientFactory, IUserRepository userRepository, IDepartmentInternalRoleRepository departmentInternalRoleRepository, IEmployeeSkillRepository employeeSkillRepository)
        {
            _httpClientFactory = httpClientFactory;
            _departmentInternalRoleRepository = departmentInternalRoleRepository;
            _userRepository = userRepository;
            _employeeSkillRepository = employeeSkillRepository;
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
    }
}
