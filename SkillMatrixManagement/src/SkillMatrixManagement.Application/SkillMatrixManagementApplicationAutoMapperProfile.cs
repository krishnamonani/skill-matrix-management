using System.Runtime.InteropServices;
using AutoMapper;
using SkillMatrixManagement.DTOs.CategoryDTO;
using SkillMatrixManagement.DTOs.DepartmentDTO;
using SkillMatrixManagement.DTOs.DepartmentInternalRoleDTO;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using SkillMatrixManagement.DTOs.ProjectDTO;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.DTOs.RoleDepartmentDTO;
using SkillMatrixManagement.DTOs.RoleDTO;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.DTOs.SkillSubtopicDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using SkillMatrixManagement.Models;

namespace SkillMatrixManagement;

public class SkillMatrixManagementApplicationAutoMapperProfile : Profile
{
    public SkillMatrixManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // mapping role table
        CreateMap<Role, RoleDto>()
           .ForMember(e => e.RoleNameString, x => x.MapFrom(r => r.Name.ToString()));

        CreateMap<Role, RoleLookupDto>()
            .ForMember(e => e.RoleNameString, x => x.MapFrom(r => r.Name.ToString()));


        // mapping user table
        CreateMap<User, UserDto>();
        CreateMap<User, UserLookupDto>();
        CreateMap<CreateUserDto, UpdateUserDto>();
        CreateMap<User, UserProjectAssignibilityStatusDto>();

        // mapping department table
        CreateMap<Department, DepartmentDto>();
        CreateMap<Department, DepartmentLookupDto>();

        // mapping skill subtopic model
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


        CreateMap<EmployeeSkill, EmployeeSkillLookupDto>();
        
        CreateMap<UpdateEmployeeSkillDto, EmployeeSkill>();

        CreateMap<DepartmentInternalRole, DepartmentInternalRoleDto>()
            .ForMember(dest => dest.RoleNameString, opt => opt.MapFrom(src => src.RoleName.ToString()));

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

        CreateMap<CreateProjectEmployeeDto, ProjectEmployee>()
        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
        .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));




        CreateMap<ProjectEmployee, ProjectEmployeeDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId));

        CreateMap<Project, ProjectDto>();
        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();
        CreateMap<Project, ProjectLookupDto>()
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.ProjectName));


        // Skill Mapping
        CreateMap<Skill, SkillDto>();
        CreateMap<Skill, SkillLookupDto>();


        CreateMap<RoleDepartment, RoleDepartmentDTO>();
    }
}
