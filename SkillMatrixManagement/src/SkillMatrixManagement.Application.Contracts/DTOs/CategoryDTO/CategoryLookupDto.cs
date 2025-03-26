using SkillMatrixManagement.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.DTOs.CategoryDTO
{
    // Minimal DTO for dropdowns or lookups
    public class CategoryLookupDto
    {
        public Guid Id { get; set; }
        public CategoryEnum CategoryName { get; set; }
        public string Description { get; set; }
    }
}
