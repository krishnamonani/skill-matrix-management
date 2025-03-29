using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SkillMatrixManagement.DTOs.AiSkillRecommendationDTO;
using SkillMatrixManagement.DTOs.Shared;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.AiServices
{
    public class AppAiRecommendationService: ApplicationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string RECOMMENDATION_END_POINT= "http://127.0.0.1:8000/recommend-skills";

        public AppAiRecommendationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ServiceResponse<string>> GetSkillRecommendation()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                // Define the request body
                var requestBody = new SkillRecommendationInputDto()
                {
                    Role = "Ai",
                    Skills = new[] { "css", "html" }
                };

                // Serialize to JSON
                string jsonBody = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(RECOMMENDATION_END_POINT, content);
                response.EnsureSuccessStatusCode();

                // Return response as string
                var responseBody = await response.Content.ReadAsStringAsync();
             
                return ServiceResponse<string>.SuccessResult(responseBody, 200);
            }
            catch (Exception)
            {
                return ServiceResponse<string>.Failure("Failed to get recommendation", 500);
            }
        }
    }
}
