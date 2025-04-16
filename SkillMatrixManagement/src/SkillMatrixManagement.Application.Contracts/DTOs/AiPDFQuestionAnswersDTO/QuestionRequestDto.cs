using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.AiPDFQuestionAnswersDTO
{
    public class QuestionRequestDto
    {
        [Required]
        public string question { get; set; }
        [Required]
        public string pdf_name { get; set; }
    }
}
