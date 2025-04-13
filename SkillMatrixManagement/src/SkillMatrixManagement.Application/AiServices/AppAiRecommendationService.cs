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
using UglyToad.PdfPig;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace SkillMatrixManagement.AiServices
{
    public class AppAiRecommendationService: ApplicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserRepository _userRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly string SKILL_RECOMMENDATION_END_POINT;
        private readonly string TEAM_RECOMMENDATION_END_POINT;

        public AppAiRecommendationService(IHttpClientFactory httpClientFactory, 
                                          IUserRepository userRepository,
                                          ISkillRepository skillRepository, 
                                          IEmployeeSkillRepository employeeSkillRepository, 
                                          IDepartmentRepository departmentRepository,
                                          IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _skillRepository = skillRepository;
            _userRepository = userRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _departmentRepository = departmentRepository;
            SKILL_RECOMMENDATION_END_POINT = configuration["AiServices:SkillRecommendationEndPoint"] ?? throw new ArgumentNullException(nameof(configuration), "Recommendation end point is not configured in appsettings.json");
            TEAM_RECOMMENDATION_END_POINT = configuration["AiServices:TeamRecommendationEndPoint"] ?? throw new ArgumentNullException(nameof(configuration), "Team recommendation end point is not configured in appsettings.json");
        }

        public async Task<ServiceResponse<SkillRecommendationResponseDto>> GetSkillRecommendation(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null) throw new Exception("User Not Found!");

                Guid? skillId = user.SkillId;

                var skillName = "General role";
                if (skillId != null)
                {
                    var skill = await _skillRepository.GetByIdAsync(skillId ?? throw new Exception("Designation not found!"));
                    if (skill == null) throw new Exception("Department Role not found!");
                    skillName = skill.Name;
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
                var requestBody = new SkillRecommendationRequestDto()
                {
                    Role = skillName,
                    Skills = skills.Count() != 0 ? skills : new List<string>(),
                    Experience = user.Experience.ToString()
                };

                // Serialize to JSON
                string jsonBody = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(SKILL_RECOMMENDATION_END_POINT, content);
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

        [HttpPost("api/app/get-team-recommendation-by-description")]
        public async Task<ServiceResponse<TeamRecommendationResponseDto>> GetTeamRecommendationAsync([FromBody]string projectDescription)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(projectDescription)) throw new ArgumentNullException(nameof(projectDescription), "Project description can not be null");
                var teamRecommendationRequest = new TeamRecommendationRequestDto()
                {
                    Description = projectDescription,
                    Employees = await GetEmployeeDetails()
                };


                var client = _httpClientFactory.CreateClient();

                // Serialize to JSON
                string jsonBody = JsonSerializer.Serialize(teamRecommendationRequest);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(TEAM_RECOMMENDATION_END_POINT, content);
                response.EnsureSuccessStatusCode();

                // Return response as string
                var responseBody = await response.Content.ReadAsStringAsync();

                var recommendationData = JsonSerializer.Deserialize<TeamRecommendationResponseDto>(responseBody);
                return ServiceResponse<TeamRecommendationResponseDto>.SuccessResult(recommendationData ?? new TeamRecommendationResponseDto(), 200);

            }
            catch (Exception ex)
            {
                return ServiceResponse<TeamRecommendationResponseDto>.Failure(ex.Message, 400);
            }
        }

        [HttpPost("api/app/get-team-description-by-pdf")]
        public async Task<ServiceResponse<TeamRecommendationResponseDto>> GetTeamRecommendationByPdfAsync(IFormFile pdf)
        {
            try
            {
                if (pdf == null || pdf.Length == 0)
                    throw new ArgumentNullException(nameof(pdf), "Pdf byte array can not be null");

                // Check ContentType
                if (pdf.ContentType != "application/pdf")
                    throw new ArgumentException("Invalid file type. Only PDF files are allowed.");

                // Check File Extension
                var extension = Path.GetExtension(pdf.FileName);
                if (extension == null || extension.ToLower() != ".pdf")
                    throw new ArgumentException("Invalid file extension. Only .pdf files are allowed.");

                var content = new StringBuilder();
                using (var memoryStream = new MemoryStream())
                {
                    await pdf.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;

                    using (PdfDocument doc = PdfDocument.Open(memoryStream))
                    {
                        foreach (var page in doc.GetPages())
                        {
                            content.AppendLine(page.Text);
                        }
                    }
                }

                var teamRecommendationRequest = new TeamRecommendationRequestDto()
                {
                    Description = content.ToString(),
                    Employees = await GetEmployeeDetails()
                };

                var client = _httpClientFactory.CreateClient();

                // Serialize to JSON
                string jsonBody = JsonSerializer.Serialize(teamRecommendationRequest);
                var apiJsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(TEAM_RECOMMENDATION_END_POINT, apiJsonContent);
                response.EnsureSuccessStatusCode();

                // Return response as string
                var responseBody = await response.Content.ReadAsStringAsync();

                var recommendationData = JsonSerializer.Deserialize<TeamRecommendationResponseDto>(responseBody);
                return ServiceResponse<TeamRecommendationResponseDto>.SuccessResult(recommendationData ?? new TeamRecommendationResponseDto(), 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<TeamRecommendationResponseDto>.Failure(ex.Message, 400);
            }
        }


        private async Task<ICollection<EmployeeDetailDto>> GetEmployeeDetails()
        {

            // fetching all the db details here
            var users = await _userRepository.GetAllAsync();
            var employeeSkills = await _employeeSkillRepository.GetAllAsync();
            var departments = await _departmentRepository.GetAllAsync();
            var departmentSkills = await _skillRepository.GetAllAsync();

            // init the Dto object
            var employeeDetailsList = new List<EmployeeDetailDto>();
            foreach(var user in users)
            {
                var department = departments.Where(dept => dept.Id == user.DepartmentId).FirstOrDefault() ?? null;
                var skill = departmentSkills.Where(irole => irole.Id == user.SkillId).FirstOrDefault() ?? null;

                string? departmentName = null;
                string? skillName = null;

                if (department != null) departmentName = department.Name;
                if (skill != null) skillName = skill.Name;

                var skills = new List<Dictionary<string, string>>();

                var skillList = employeeSkills.Where(eskill => eskill.UserId == user.Id).Select(s => s.CoreSkillName).ToList();
                var proficiencyList = employeeSkills.Where(eskill => eskill.UserId == user.Id).Select(s => s.SelfAssessedProficiency.ToString()).ToList();

                if (skillList.Count != proficiencyList.Count) continue;

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
                           Designation = skillName,
                           Skills = skillList,
                           Proficiencies = proficiencyList,
                           ProjectStatus = user.IsAvailable.ToString()
                       }
                    );
            }

            return employeeDetailsList;
        }
    }
}
