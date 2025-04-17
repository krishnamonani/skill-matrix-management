using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillMatrixManagement.DTOs.EmailDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Services;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace SkillMatrixManagement.Controllers
{
    [RemoteService]
    [Route("api/app/email")]
    public class EmailController : AbpControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<ActionResult<ServiceResponse>> SendEmail([FromBody] SendEmailDto input)
        {
            try
            {
                await _emailService.SendEmailAsync(
                    input.TargetEmailAddress,
                    input.Subject,
                    input.Body,
                    input.SenderEmailAddress
                );

                return Ok(ServiceResponse.SuccessResult(200, "Email sent successfully"));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ServiceResponse.Failure($"Failed to send email: {ex.Message}", 400));
            }
        }
        
        [HttpGet("send-email")]
        public async Task<ActionResult<ServiceResponse>> SendEmailViaQuery(
            [FromQuery] string targetEmailAddress,
            [FromQuery] string subject,
            [FromQuery] string body,
            [FromQuery] string senderEmailAddress = null)
        {
            try
            {
                await _emailService.SendEmailAsync(
                    targetEmailAddress,
                    subject, 
                    body,
                    senderEmailAddress
                );
                
                return Ok(ServiceResponse.SuccessResult(200, "Email sent successfully"));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ServiceResponse.Failure($"Failed to send email: {ex.Message}", 400));
            }
        }
    }
}
