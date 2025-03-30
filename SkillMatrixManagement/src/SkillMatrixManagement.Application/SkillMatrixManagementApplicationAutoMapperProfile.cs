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
            .ForMember(dest => dest.SkillId, opt => opt.MapFrom(src => src.SkillId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ReqExpertiseLevelId, opt => opt.MapFrom(src => src.ReqExpertiseLevelId))
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id is auto-generated
           .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Skill entity is loaded separately




        CreateMap<SkillSubtopic, SkillSubtopicDto>();


        CreateMap<CreateSkillSubtopicDto, SkillSubtopic>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id is auto-generated
           .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Skill entity is loaded separately


        CreateMap<EmployeeSkill, EmployeeSkillDto>()
             .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CoreSkillName, opt => opt.MapFrom(src => src.CoreSkillName))
            .ForMember(dest => dest.SelfAssessedProficiency, opt => opt.MapFrom(src => src.SelfAssessedProficiency))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));



        CreateMap<CreateEmployeeSkillDto, EmployeeSkill>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.CoreSkillName, opt => opt.MapFrom(src => src.CoreSkillName))
            .ForMember(dest => dest.SelfAssessedProficiency, opt => opt.MapFrom(src => src.SelfAssessedProficiency))
            .ForMember(dest => dest.ManagerAssignedProficiency, opt => opt.MapFrom(src => src.ManagerAssignedProficiency))
            .ForMember(dest => dest.EndorsedBy, opt => opt.MapFrom(src => src.EndorsedBy))
            .ForMember(dest => dest.EndorsedAt, opt => opt.MapFrom(src => src.EndorsedAt));
            //.ForMember(dest => dest.SkillDescription, opt => opt.MapFrom(src => src.SkillDescription));


        CreateMap<UpdateEmployeeSkillDto, EmployeeSkill>();


        CreateMap<EmployeeSkill,EmployeeSkillLookupDto>()
        .ForMember(dest => dest.Id, opt => opt.Ignore()); // ID is auto-generated
        CreateMap<UpdateEmployeeSkillDto, EmployeeSkill>();
    }
}
