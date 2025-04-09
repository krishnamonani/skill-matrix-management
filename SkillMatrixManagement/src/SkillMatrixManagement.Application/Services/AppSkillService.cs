using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppSkillService : ApplicationService, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        private const string GENERAL_SKILL_EXCEPTION_CODE = "SKILL_EXCEPTION_CODE_000";

        public AppSkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var skills = await _skillRepository.WithDetailsAsync();
                var count = includeDeleted
                    ? await skills.IgnoreQueryFilters().CountAsync()
                    : await skills.CountAsync(s => !s.IsDeleted);
                return ServiceResponse<int>.SuccessResult(count, 200, "Count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillDto>> CreateAsync(CreateSkillDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse<SkillDto>.Failure("Input cannot be null.", 400);
                }
                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    return ServiceResponse<SkillDto>.Failure("Skill name cannot be empty.", 400);
                }

                var skill = _mapper.Map<Skill>(input);
                var createdSkill = await _skillRepository.CreateAsync(skill);
                var skillDto = _mapper.Map<SkillDto>(createdSkill);
                return ServiceResponse<SkillDto>.SuccessResult(skillDto, 201, "Skill created successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<SkillDto>.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, ex.Code == SkillMatrixManagementDomainErrorCodes.Skill.SKILL_ALREADY_EXISTS_WITH_SAME_NAME ? 409 : 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillDto>.Failure($"Failed to create skill: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill ID cannot be empty.", 400);
                }

                await _skillRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill soft-deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete skill: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<SkillDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                List<Skill> skills;
                if (includeDeleted)
                {
                    var skillsWithDetails = await _skillRepository.WithDetailsAsync();
                    skills = await skillsWithDetails.ToListAsync();
                }
                else
                {
                    skills = await _skillRepository.GetAllAsync();
                }

                var skillDtos = _mapper.Map<List<SkillDto>>(skills);
                return ServiceResponse<List<SkillDto>>.SuccessResult(skillDtos, 200, "Skills retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillDto>>.Failure($"Failed to retrieve skills: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse<SkillDto>.Failure("Skill ID cannot be empty.", 400);
                }

                var skill = await _skillRepository.GetByIdAsync(id);
                var skillDto = _mapper.Map<SkillDto>(skill);
                return ServiceResponse<SkillDto>.SuccessResult(skillDto, 200, "Skill retrieved successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<SkillDto>.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillDto>.Failure($"Failed to retrieve skill: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<SkillLookupDto>>> GetLookupAsync()
        {
            try
            {
                var skills = await _skillRepository.GetAllAsync(); // Only active skills
                var lookupDtos = _mapper.Map<List<SkillLookupDto>>(skills);
                return ServiceResponse<List<SkillLookupDto>>.SuccessResult(lookupDtos, 200, "Skill lookup retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillLookupDto>>.Failure($"Failed to retrieve skill lookup: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillPagedResultDto>> GetPagedListAsync(SkillFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse<SkillPagedResultDto>.Failure("Filter input cannot be null.", 400);
                }

                var query = await _skillRepository.WithDetailsAsync();

                // Apply filters
                if (!string.IsNullOrWhiteSpace(input.Name))
                {
                    query = query.Where(s => s.Name.Contains(input.Name));
                }
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(s => s.IsDeleted == input.IsDeleted.Value);
                }
                else
                {
                    query = query.Where(s => !s.IsDeleted); // Default to active skills
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(s => s.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(s => s.CreationTime <= input.CreationTimeEnd.Value);
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(s => s.LastModificationTime >= input.LastModificationTimeStart.Value);
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(s => s.LastModificationTime <= input.LastModificationTimeEnd.Value);
                }

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(input.Sorting))
                {
                    var sortParts = input.Sorting.Trim().Split(' ');
                    var propertyName = sortParts[0];
                    var isDescending = sortParts.Length > 1 && sortParts[1].ToUpper() == "DESC";

                    switch (propertyName.ToLower())
                    {
                        case "name":
                            query = isDescending ? query.OrderByDescending(s => s.Name) : query.OrderBy(s => s.Name);
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(s => s.CreationTime) : query.OrderBy(s => s.CreationTime);
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(s => s.LastModificationTime) : query.OrderBy(s => s.LastModificationTime);
                            break;
                        default:
                            query = query.OrderBy(s => s.Name); // Default sorting
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(s => s.Name); // Default sorting
                }

                // Apply pagination
                var totalCount = await query.LongCountAsync();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<SkillDto>>(items);

                var result = new SkillPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<SkillPagedResultDto>.SuccessResult(result, 200, "Paged skills retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillPagedResultDto>.Failure($"Failed to retrieve paged skills: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill ID cannot be empty.", 400);
                }

                await _skillRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill permanently deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete skill: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> RestoreSkillAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill ID cannot be empty.", 400);
                }

                await _skillRepository.RestoreSkillAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill restored successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, ex.Code == SkillMatrixManagementDomainErrorCodes.Skill.SKILL_NOT_FOUND_OR_NOT_DELETED ? 400 : 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore skill: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse.Failure("Input cannot be null.", 400);
                }
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill ID cannot be empty.", 400);
                }
                if (string.IsNullOrWhiteSpace(input.Name))
                {
                    return ServiceResponse.Failure("Skill name cannot be empty.", 400);
                }

                var skill = await _skillRepository.GetByIdAsync(id);
                _mapper.Map(input, skill);
                await _skillRepository.UpdateAsync(skill);
                return ServiceResponse.SuccessResult(200, "Skill updated successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillService.GENERAL_SKILL_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to update skill: {ex.Message}", 500);
            }
        }
    }
}