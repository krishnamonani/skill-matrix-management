using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shouldly;
using Volo.Abp.Emailing;
using Volo.Abp.Settings;
using Xunit;


namespace SkillMatrixManagement.Emailing
{
    public class EmailTests : SkillMatrixManagementDomainTestBase<SkillMatrixManagementDomainTestModule>
    {
        private readonly IEmailSender _emailSender;
        private readonly ISettingProvider _settingProvider;

        public EmailTests()
        {
            _emailSender = GetRequiredService<IEmailSender>();
            _settingProvider = GetRequiredService<ISettingProvider>();
        }

        [Fact]
        [Trait("Category", "Manual")]
        public async Task Should_Have_Valid_Email_Options()
        {
            // Get email settings directly using the SettingProvider
            var defaultFromAddress = await _settingProvider.GetOrNullAsync("Abp.Mailing.DefaultFromAddress");
            var defaultFromDisplayName = await _settingProvider.GetOrNullAsync("Abp.Mailing.DefaultFromDisplayName");
            var smtpHost = await _settingProvider.GetOrNullAsync("Abp.Mailing.Smtp.Host");
            var smtpPort = await _settingProvider.GetOrNullAsync("Abp.Mailing.Smtp.Port");

            defaultFromAddress.ShouldNotBeNullOrEmpty("DefaultFromAddress should be set");
            defaultFromDisplayName.ShouldNotBeNullOrEmpty("DefaultFromDisplayName should be set");
            smtpHost.ShouldNotBeNullOrEmpty("SMTP Host should be set");
            int.Parse(smtpPort ?? "0").ShouldBeGreaterThan(0, "SMTP Port should be set");
        }

        [Fact]
        [Trait("Category", "Manual")]
        public async Task Should_Send_Test_Email()
        {
            // This test is marked as manual because it would actually send an email
            // Change this to a real email address for testing
            var testEmailAddress = "skillmatrix.promact@gmail.com";
            
            await _emailSender.SendAsync(
                testEmailAddress,
                "Test Email from Skills Matrix System",
                "This is a test email to verify if the email system is working.",
                isBodyHtml: false
            );

            // No assertion needed - if it doesn't throw, it worked
        }
    }
}
