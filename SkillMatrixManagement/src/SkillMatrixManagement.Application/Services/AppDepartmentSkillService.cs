using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppDepartmentSkillService:ApplicationService
    {
        private readonly IDepartmentSkillRepository _departmentSkillRepository;

        public AppDepartmentSkillService(IDepartmentSkillRepository departmentSkillRepository)
        {
            _departmentSkillRepository = departmentSkillRepository;
        }


        public async Task<ServiceResponse<List<DepartmentSkill>>> GetSkillsByDepartmentIdAsync(Guid DepartmentId)
        {
            try
            {
                var Skills=await _departmentSkillRepository.GetSkillsByDepartmentIdAsync(DepartmentId);
                return ServiceResponse<List<DepartmentSkill>>.SuccessResult(Skills, 200);
            }
            catch(Exception ex)
            {
                return ServiceResponse<List<DepartmentSkill>>.Failure(ex.Message, 500);
            }
        }
    }
}
