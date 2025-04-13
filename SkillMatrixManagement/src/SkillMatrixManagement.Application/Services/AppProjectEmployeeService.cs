using AutoMapper;
using SkillMatrixManagement.DTOs.ProjectEmployeeDTO;
using SkillMatrixManagement.DTOs.Shared;
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

        public async Task<ServiceResponse> AssignEmployeesToProjectAsync(Guid projectId, List<Guid> employeeIds)
        {
            


                var project = await _projectRepository.GetAsync(projectId);
                if (project == null) throw new BusinessException("Project not found");

            using (var uow = _unitOfWorkManager.Begin())
            {
                try
                {
                    // Get all existing assignments
                    var existingAssignments = await _projectEmployeeRepository.GetAllAsync();
                    existingAssignments = existingAssignments.FindAll(p => p.ProjectId == projectId);

                    // Employees to add: those in employeeIds but not in existing assignments
                    var employeesToAdd = employeeIds
                        .Where(eId => !existingAssignments.Any(pe => pe.UserId == eId && !pe.IsDeleted))
                        .ToList();

                    // Employees to remove: those in existing assignments but not in employeeIds
                    var employeesToRemove = existingAssignments
                        .Where(pe => !employeeIds.Contains(pe.UserId) && !pe.IsDeleted)
                        .ToList();

                    // Add new assignments
                    foreach (var employeeId in employeesToAdd)
                    {
                        var existing = await _projectEmployeeRepository.IsExistTheUserIdProjectIdAsync(employeeId, projectId);
                        if (!existing)
                        {
                            var projectEmployee = new ProjectEmployee
                            {
                                ProjectId = projectId,
                                UserId = employeeId,
                            };
                            await _projectEmployeeRepository.CreateAsync(projectEmployee);
                        }
                    }

                    // Remove existing assignments by marking as deleted
                    foreach (var projectEmployee in employeesToRemove)
                    {
                       await _projectEmployeeRepository.DeleteAsync(projectEmployee.Id);
                    }

                    await uow.CompleteAsync();
                    return ServiceResponse.SuccessResult(200, "Successfully assigned project to the selected developers and updated assignments");
                }
                catch (Exception ex)
                {
                    throw new BusinessException("Failed to assign employees to project", ex.Message);
                }
            }

            }
        }
    }

