namespace SkillMatrixManagement.Emailing.Models
{

    public class WelcomeEmailModel
    {
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        public string ResetPasswordLink { get; set; }
    }
}
