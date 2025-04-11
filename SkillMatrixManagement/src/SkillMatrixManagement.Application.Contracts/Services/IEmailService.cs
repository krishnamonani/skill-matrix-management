using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public interface IEmailService : IApplicationService
    {
        Task SendWelcomeEmailAsync(
            string targetEmailAddress,
            string username,
            string password,
            string resetPasswordLink);

        Task SendEmailAsync(
            string targetEmailAddress,
            string subject,
            string body,
            string senderEmailAddress = null);
    }
}
