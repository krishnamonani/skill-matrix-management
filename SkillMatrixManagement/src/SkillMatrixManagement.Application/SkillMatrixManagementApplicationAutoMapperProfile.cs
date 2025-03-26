using AutoMapper;
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
        CreateMap<SkillSubtopic, SkillSubtopicDto>();

        CreateMap<CreateSkillSubtopicDto, SkillSubtopic>()
           .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id is auto-generated
           .ForMember(dest => dest.Skill, opt => opt.Ignore()); // Skill entity is loaded separately


    }
}
