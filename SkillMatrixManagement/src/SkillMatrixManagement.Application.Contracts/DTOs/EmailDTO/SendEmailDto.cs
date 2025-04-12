namespace SkillMatrixManagement.DTOs.EmailDTO
{
    public class SendEmailDto
    {
        public string SenderEmailAddress { get; set; }
        public string TargetEmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
