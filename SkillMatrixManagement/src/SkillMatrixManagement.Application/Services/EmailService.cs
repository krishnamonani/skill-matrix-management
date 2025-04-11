using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SkillMatrixManagement.Emailing;
using SkillMatrixManagement.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.TextTemplating;

namespace SkillMatrixManagement.Services
{
    public class EmailService : SkillMatrixManagementAppService, IEmailService, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly ILogger<EmailService> _logger;

        public EmailService(
            IEmailSender emailSender,
            ITemplateRenderer templateRenderer,
            ILogger<EmailService> logger)
        {
            _emailSender = emailSender;
            _templateRenderer = templateRenderer;
            _logger = logger;
        }

        public async Task SendWelcomeEmailAsync(
            string targetEmailAddress,
            string username,
            string password,
            string resetPasswordLink)
        {
            try
            {
                _logger.LogInformation("Attempting to send welcome email to {Email}", targetEmailAddress);
                
                var subject = "Welcome to Skill Matrix Management System";
                var body = await _templateRenderer.RenderAsync(
                    "Welcome", 
                    new WelcomeEmailModel
                    {
                        Username = username,
                        Password = password,
                        ResetPasswordLink = resetPasswordLink
                    }
                );

                await _emailSender.SendAsync(
                    targetEmailAddress,
                    subject,
                    body,
                    isBodyHtml: true
                );
                
                _logger.LogInformation("Welcome email sent successfully to {Email}", targetEmailAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send welcome email to {Email}: {Error}", targetEmailAddress, ex.Message);
                throw;
            }
        }

        public async Task SendEmailAsync(
            string targetEmailAddress,
            string subject,
            string body,
            string senderEmailAddress = null)
        {
            try
            {
                _logger.LogInformation("Sending email to {Email} with subject {Subject}", targetEmailAddress, subject);
                
                if (string.IsNullOrEmpty(senderEmailAddress))
                {
                    await _emailSender.SendAsync(
                        targetEmailAddress,
                        subject,
                        body,
                        isBodyHtml: true
                    );
                }
                else
                {
                    await _emailSender.SendAsync(
                        senderEmailAddress,
                        targetEmailAddress,
                        subject,
                        body,
                        isBodyHtml: true
                    );
                }
                
                _logger.LogInformation("Email sent successfully to {Email}", targetEmailAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email}: {Error}", targetEmailAddress, ex.Message);
                throw;
            }
        }
    }
}
