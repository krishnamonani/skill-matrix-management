using System;
using System.Collections.Generic;
using Volo.Abp.Identity; // Required for IdentityUserDto

namespace SkillMatrixManagement.Application.Dtos // Adjust namespace if needed
{
    public class CustomLoginResultDto
    {

        public bool Succeeded { get; set; }

        public string Message { get; set; }


        public List<string> Roles { get; set; } = new List<string>();

        public IdentityUserDto User { get; set; }
    }
}