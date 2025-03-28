using System.Runtime.InteropServices;
using AutoMapper;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
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
        
        //category Mapping
        CreateMap<CreateCategoryDto, Category>();

        // Mapping Update DTO to Entity (Avoid overwriting with null values)
        CreateMap<UpdateCategoryDto, Category>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Category, CategoryDto>().
        ForMember(dest => dest.CategoryNameString, opt => opt.MapFrom(src => src.CategoryName.ToString()));

        CreateMap<Category, CategoryLookupDto>().
        ForMember(dest => dest.CategoryNameString, opt => opt.MapFrom(src => src.CategoryName.ToString()));

        //DepartmentInternalRole Mapping 
        CreateMap<CreateDepartmentInternalRoleDto, DepartmentInternalRole>();
        CreateMap<DepartmentInternalRole, DepartmentInternalRoleDto>().ForMember(dest => dest.DepartmentRole, opt => opt.MapFrom(src => src.RoleName.ToString()))
            .ForMember(dest => dest.RolePosition, opt => opt.MapFrom(src => src.Position.ToString()));

        CreateMap<DepartmentInternalRole, DepartmentInternalRoleLookupDto>()
            .ForMember(dest => dest.DepartmentRole, opt => opt.MapFrom(src => src.RoleName.ToString()));
        CreateMap<UpdateDepartmentInternalRoleDto, DepartmentInternalRole>()
          .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
          .ForMember(dest => dest.RoleDescription, opt => opt.MapFrom(src => src.RoleDescription))
          .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position));
    }
}
