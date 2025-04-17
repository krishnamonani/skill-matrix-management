using AutoMapper;
using SkillMatrixManagement.DTOs.RoleDepartmentDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppRoleDepartmentService:ApplicationService, IRoleDepertmentService
    {
        private readonly IRoleDepartmentRepository _roleDepartmentRepository;
        private IMapper _mapper;

        public AppRoleDepartmentService(IRoleDepartmentRepository roleDepartmentRepository, IMapper mapper)
        {
            _roleDepartmentRepository = roleDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<RoleDepartmentDTO>>> GetDepartmentByRoleId(Guid RoleId)
        {
            try
            {
                var Depts= await _roleDepartmentRepository.GetDepartMentByRoleIdAsync(RoleId);
                var DeptsDTO = _mapper.Map<List<RoleDepartmentDTO>>(Depts);
                return ServiceResponse<List<RoleDepartmentDTO>>.SuccessResult(DeptsDTO, 200);
            }
            catch(Exception ex)
            {
                return ServiceResponse<List<RoleDepartmentDTO>>.Failure(ex.Message, 500);
            }
        }
    }
}
