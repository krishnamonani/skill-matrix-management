using AutoMapper;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.UserDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;


namespace SkillMatrixManagement.Services
{
    public class AppProjectEmployeeService : ApplicationService, IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public AppProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository, IMapper mapper, IProjectRepository projectRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        // Create a new ProjectEmployee
        public async Task<ServiceResponse<ProjectEmployeeDto>> CreateAsync(CreateProjectEmployeeDto input)
        {
            try
            {
                var projectEmployee = _mapper.Map<ProjectEmployee>(input);
                projectEmployee.IsDeleted = false;

                var createdEntity = await _projectEmployeeRepository.CreateAsync(projectEmployee);
                var dto = _mapper.Map<ProjectEmployeeDto>(createdEntity);

                return ServiceResponse<ProjectEmployeeDto>.SuccessResult(dto, 201, "ProjectEmployee created successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<ProjectEmployeeDto>.Failure(ex.Message, ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectEmployeeDto>.Failure($"Error creating ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Get ProjectEmployee by ID
        public async Task<ServiceResponse<ProjectEmployeeDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(id);
                if (projectEmployee == null)
                {
                    return ServiceResponse<ProjectEmployeeDto>.Failure("ProjectEmployee not found.", 404);
                }

                var dto = _mapper.Map<ProjectEmployeeDto>(projectEmployee);
                return ServiceResponse<ProjectEmployeeDto>.SuccessResult(dto, 200, "ProjectEmployee retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectEmployeeDto>.Failure($"Error retrieving ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Get all ProjectEmployees
        public async Task<ServiceResponse<List<ProjectEmployeeDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                var projectEmployees = await _projectEmployeeRepository.GetAllAsync();

                if (!includeDeleted)
                {
                    projectEmployees = projectEmployees.Where(pe => !pe.IsDeleted).ToList();
                }

                var dtos = _mapper.Map<List<ProjectEmployeeDto>>(projectEmployees);
                return ServiceResponse<List<ProjectEmployeeDto>>.SuccessResult(dtos, 200, "ProjectEmployees retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProjectEmployeeDto>>.Failure($"Error retrieving ProjectEmployees: {ex.Message}", 500);
            }
        }

        // Get paginated ProjectEmployees
        public async Task<ServiceResponse<ProjectEmployeePagedResultDto>> GetPagedListAsync(ProjectEmployeeFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse<ProjectEmployeePagedResultDto>.Failure("Invalid filter input.", 400);
                }

                var query = await _projectEmployeeRepository.GetAllAsync();

                // Apply filters
                if (input.UserId.HasValue)
                {
                    query = query.Where(pe => pe.UserId == input.UserId.Value).ToList();
                }
                if (input.ProjectId.HasValue)
                {
                    query = query.Where(pe => pe.ProjectId == input.ProjectId.Value).ToList();
                }

                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(pe => pe.IsDeleted == input.IsDeleted.Value).ToList();
                }
                else
                {
                    query = query.Where(pe => !pe.IsDeleted).ToList();
                }

                // Apply sorting
                query = input.Sorting?.ToLower() switch
                {
                    "userid desc" => query.OrderByDescending(pe => pe.UserId).ToList(),
                    "projectid desc" => query.OrderByDescending(pe => pe.ProjectId).ToList(),
                    "creationtime desc" => query.OrderByDescending(pe => pe.CreationTime).ToList(),
                    "lastmodificationtime desc" => query.OrderByDescending(pe => pe.LastModificationTime).ToList(),
                    _ => query.OrderBy(pe => pe.CreationTime).ToList()
                };

                // Apply pagination
                var totalCount = query.LongCount();
                var items = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
                var itemDtos = _mapper.Map<List<ProjectEmployeeDto>>(items);
                var result = new ProjectEmployeePagedResultDto(totalCount, itemDtos);

                return ServiceResponse<ProjectEmployeePagedResultDto>.SuccessResult(result, 200, "Paged project employees retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProjectEmployeePagedResultDto>.Failure($"Failed to retrieve paged project employees: {ex.Message}", 500);
            }
        }

        // Update ProjectEmployee
        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateProjectEmployeeDto input)
        {
            try
            {
                var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(id);
                if (projectEmployee == null)
                {
                    return ServiceResponse.Failure("ProjectEmployee not found.", 404);
                }

                _mapper.Map(input, projectEmployee);
                await _projectEmployeeRepository.UpdateAsync(projectEmployee);

                return ServiceResponse.SuccessResult(204, "ProjectEmployee updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error updating ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Soft delete ProjectEmployee
        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                await _projectEmployeeRepository.DeleteAsync(id);
                return ServiceResponse.SuccessResult(204, "ProjectEmployee soft deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error soft deleting ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Permanent delete ProjectEmployee
        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                await _projectEmployeeRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(204, "ProjectEmployee permanently deleted.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error permanently deleting ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Restore soft-deleted ProjectEmployee
        public async Task<ServiceResponse> RestoreProjectEmployeeAsync(Guid id)
        {
            try
            {
                await _projectEmployeeRepository.RestoreProjectEmployeeAsync(id);
                return ServiceResponse.SuccessResult(204, "ProjectEmployee restored successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Error restoring ProjectEmployee: {ex.Message}", 500);
            }
        }

        // Get ProjectEmployee count
        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var projectEmployees = await _projectEmployeeRepository.GetAllAsync();

                if (!includeDeleted)
                {
                    projectEmployees = projectEmployees.Where(pe => !pe.IsDeleted).ToList();
                }

                int count = projectEmployees.Count;
                return ServiceResponse<int>.SuccessResult(count, 200, "ProjectEmployee count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Error counting ProjectEmployees: {ex.Message}", 500);
            }
        }

        // Get lookup data for ProjectEmployee
        public async Task<ServiceResponse<List<ProjectEmployeeLookupDto>>> GetLookupAsync()
        {
            try
            {
                var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
                var lookupDtos = projectEmployees.Select(pe => new ProjectEmployeeLookupDto
                {
                    Id = pe.Id,
                    UserId = pe.UserId,
                    ProjectId = pe.ProjectId
                }).ToList();

                return ServiceResponse<List<ProjectEmployeeLookupDto>>.SuccessResult(lookupDtos, 200, "Lookup data retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProjectEmployeeLookupDto>>.Failure($"Error retrieving lookup data: {ex.Message}", 500);
            }
        }

        // Get all fields where UserId matches the given one
        public async Task<ServiceResponse<List<ProjectEmployeeDto>>> GetAllFieldsByUserIdAsync(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    return ServiceResponse<List<ProjectEmployeeDto>>.Failure("User ID cannot be empty.", 400);
                }

                // Fetch all project employees where UserId matches
                var projectEmployees = await _projectEmployeeRepository.GetByUserIdAsync(userId);
                var projects = await _projectRepository.GetAllAsync();
                foreach (var pe in projectEmployees)
                {
                    pe.Project = projects.Where(p => p.Id == pe.ProjectId).FirstOrDefault();
                }

                if (!projectEmployees.Any())
                {
                    return ServiceResponse<List<ProjectEmployeeDto>>.Failure("No records found for the given User ID.", 404);
                }

                // Map the result to DTOs
                var projectEmployeeDtos = _mapper.Map<List<ProjectEmployeeDto>>(projectEmployees);
                return ServiceResponse<List<ProjectEmployeeDto>>.SuccessResult(projectEmployeeDtos, 200, "Records retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<ProjectEmployeeDto>>.Failure($"Error retrieving records: {ex.Message}", 500);
            }




        }


        public async Task<ServiceResponse<List<BulkProjectAssignDTO>>> AssignEmployeesToProjectAsync(List<BulkProjectAssignDTO> ProjectEmployeeDetails)
        {
            if (!ProjectEmployeeDetails.Any() == null)
            {
                return ServiceResponse<List<BulkProjectAssignDTO>>.Failure("Data Can't be null", 400);
            }
            foreach (var ProjectEmployeeDetail in ProjectEmployeeDetails)
            {
                var project = await _projectRepository.GetByIdAsync(ProjectEmployeeDetail.ProjectId);
                if (project == null) throw new BusinessException("Project not found");

                using (var uow = _unitOfWorkManager.Begin())
                {
                    try
                    {
                        // Get all existing assignments for the project
                        var existingAssignments = await _projectEmployeeRepository.GetAllAsync();
                        //existingAssignments = existingAssignments.FindAll(p => p.ProjectId == ProjectEmployeeDetail.ProjectId && !p.IsDeleted);

                        // Employees to add: those in employeeIds but not in existing assignments
                        //var employeesToAdd = ProjectEmployeeDetail.EmployeeId
                        //    .Where(eId => !existingAssignments.Any(pe => pe.UserId == eId))
                        //    .ToList();

                        // Add new assignments
                        var existing = await _projectEmployeeRepository.IsExistTheUserIdProjectIdAsync(ProjectEmployeeDetail.EmployeeId, ProjectEmployeeDetail.ProjectId);
                        if (!existing)
                        {
                            var projectEmployee = new ProjectEmployee
                            {
                                ProjectId = ProjectEmployeeDetail.ProjectId,
                                UserId = ProjectEmployeeDetail.EmployeeId,
                                AssignibilityPercentage= ProjectEmployeeDetail.AssignabilityPercentage,
                                BillablePercentage = ProjectEmployeeDetail.AssignabilityPercentage,
                                ProjectStartDate=ProjectEmployeeDetail.StartDate,
                                ProjectEndDate = ProjectEmployeeDetail.EndDate,


                            };
                            await _projectEmployeeRepository.CreateAsync(projectEmployee);
                        }
                       

                        await uow.CompleteAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new BusinessException("Failed to assign employees to project", ex.Message);
                    }
                }

            }
            return ServiceResponse<List<BulkProjectAssignDTO>>.SuccessResult(ProjectEmployeeDetails, 200);



        }

        public async Task<ServiceResponse<bool>> RemoveEmployeeFromProjectAsync(Guid projectId, Guid employeeId)
        {
            var project = await _projectRepository.GetAsync(projectId);
            if (project == null) throw new BusinessException("Project not found");

            using (var uow = _unitOfWorkManager.Begin())
            {
                try
                {
                    // Get existing assignment for the specific employee and project
                    var existingAssignments = await _projectEmployeeRepository.GetAllAsync();
                    var projectEmployeeData = existingAssignments
                        .FirstOrDefault(pe => pe.ProjectId == projectId && pe.UserId == employeeId && !pe.IsDeleted);

                    if (projectEmployeeData == null)
                    {
                        throw new BusinessException("Employee is not assigned to this project");
                    }

                    // Remove the assignment by marking as deleted
                    projectEmployeeData.IsDeleted = true;

                    await uow.SaveChangesAsync();
                    return ServiceResponse<bool>.SuccessResult(true, 200);
                }
                catch (Exception ex)
                {
                    throw new BusinessException("Failed to remove employee from project", ex.Message);
                }
            }
        }



        public async Task<ServiceResponse<List<AssingedUserProjectDTO>>> GetByProjectIdAsync(Guid projectId)
        {
            try
            {



                var EmployeeList = await _projectEmployeeRepository.GetByProjectIdAsync(projectId);
                //var employeeListDto = _mapper.Map<List<UserDto>>(EmployeeList);
                if (EmployeeList == null)
                {
                    return ServiceResponse<List<AssingedUserProjectDTO>>.Failure("No one is assigned to this project", 400);
                }
                return ServiceResponse<List<AssingedUserProjectDTO>>.SuccessResult(EmployeeList, 201);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<AssingedUserProjectDTO>>.Failure(ex.Message, 400);

            }
        }


        public async Task<ServiceResponse<int>> GetCountOfAssignedUserByProjectIdAsync(Guid projectId)
        {

            var EmployeeList = await _projectEmployeeRepository.GetByProjectIdAsync(projectId);
            var count = EmployeeList.Count();
            if (EmployeeList == null)
            {
                return ServiceResponse<int>.Failure("No one is Assigned to This project", 404);
            }
            return ServiceResponse<int>.SuccessResult(count, 201);
        }
    }
}


