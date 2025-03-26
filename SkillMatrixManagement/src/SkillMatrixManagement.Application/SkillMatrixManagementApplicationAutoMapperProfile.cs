using AutoMapper;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.Models;

namespace SkillMatrixManagement;

public class SkillMatrixManagementApplicationAutoMapperProfile : Profile
{
    public SkillMatrixManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Role, RoleDto>()
            .ForMember(e => e.RoleNameString, x => x.MapFrom(r => r.Name.ToString()));

        CreateMap<Role, RoleLookupDto>()
            .ForMember(e => e.RoleNameString, x => x.MapFrom(r => r.Name.ToString()));
    }
}
