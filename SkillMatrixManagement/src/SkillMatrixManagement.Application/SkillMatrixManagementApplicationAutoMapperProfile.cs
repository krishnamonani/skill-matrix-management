using AutoMapper;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.DTOs.SkillSubtopicDTO;
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
        CreateMap<SkillSubtopic, SkillSubtopicDto>();

        CreateMap<CreateSkillSubtopicDto, SkillSubtopic>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id is auto-generated
           .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Skill entity is loaded separately
        CreateMap<SkillSubtopic, SkillSubtopicDto>();

        CreateMap<CreateSkillSubtopicDto, SkillSubtopic>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id is auto-generated
           .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Skill entity is loaded separately


        CreateMap<EmployeeSkill, EmployeeSkillDto>().ReverseMap();
        CreateMap<CreateEmployeeSkillDto, EmployeeSkill>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID is auto-generated
        CreateMap<UpdateEmployeeSkillDto, EmployeeSkill>();


        CreateMap<EmployeeSkill,EmployeeSkillLookupDto>()
        .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID is auto-generated
        CreateMap<UpdateEmployeeSkillDto, EmployeeSkill>();
    }
}
