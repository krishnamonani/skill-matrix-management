using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.Constants;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillHistoryDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppSkillHistoryService : ApplicationService, ISkillHistoryService
    {
        private readonly ISkillHistoryRepository _skillHistoryRepository;
        private readonly IMapper _mapper;
        private const string GENERAL_SKILL_HISTORY_EXCEPTION_CODE = "SKILL-HISTORY-000";

        public AppSkillHistoryService(ISkillHistoryRepository skillHistoryRepository, IMapper mapper)
        {
            _skillHistoryRepository = skillHistoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var skillHistories = await _skillHistoryRepository.WithDetailsAsync();
                var count = includeDeleted
                    ? await skillHistories.IgnoreQueryFilters().CountAsync()
                    : await skillHistories.CountAsync(sh => !sh.IsDeleted);
                return ServiceResponse<int>.SuccessResult(count, 200, "Count retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillHistoryDto>> CreateAsync(CreateSkillHistoryDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse<SkillHistoryDto>.Failure("Input cannot be null.", 400);
                }
                if (input.UserId == Guid.Empty)
                {
                    return ServiceResponse<SkillHistoryDto>.Failure("User ID cannot be empty.", 400);
                }
                if (string.IsNullOrWhiteSpace(input.CoreSkillName))
                {
                    return ServiceResponse<SkillHistoryDto>.Failure("Skill name cannot be empty.", 400);
                }
                if (!Enum.IsDefined(typeof(ProficiencyEnum), input.ChangedProficiencyLevel))
                {
                    return ServiceResponse<SkillHistoryDto>.Failure("Invalid proficiency level specified.", 400);
                }

                var skillHistory = _mapper.Map<SkillHistory>(input);
                skillHistory.UserIdBasedVersion = await CalculateUserIdBasedVersion(input.UserId);
                var createdSkillHistory = await _skillHistoryRepository.CreateAsync(skillHistory);
                var skillHistoryDto = _mapper.Map<SkillHistoryDto>(createdSkillHistory);
                return ServiceResponse<SkillHistoryDto>.SuccessResult(skillHistoryDto, 201, "Skill history created successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<SkillHistoryDto>.Failure(ex.Message, ex.Code ?? AppSkillHistoryService.GENERAL_SKILL_HISTORY_EXCEPTION_CODE, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillHistoryDto>.Failure($"Failed to create skill history: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill history ID cannot be empty.", 400);
                }

                await _skillHistoryRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill history soft-deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillHistoryService.GENERAL_SKILL_HISTORY_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to delete skill history: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<SkillHistoryDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                List<SkillHistory> skillHistories;
                if (includeDeleted)
                {
                    var skillHistoriesWithDetails = await _skillHistoryRepository.WithDetailsAsync();
                    skillHistories = await skillHistoriesWithDetails.IgnoreQueryFilters().ToListAsync();
                }
                else
                {
                    skillHistories = await _skillHistoryRepository.GetAllAsync();
                }

                var skillHistoryDtos = _mapper.Map<List<SkillHistoryDto>>(skillHistories);
                return ServiceResponse<List<SkillHistoryDto>>.SuccessResult(skillHistoryDtos, 200, "Skill histories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillHistoryDto>>.Failure($"Failed to retrieve skill histories: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillHistoryDto>> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse<SkillHistoryDto>.Failure("Skill history ID cannot be empty.", 400);
                }

                var skillHistory = await _skillHistoryRepository.GetByIdAsync(id);
                var skillHistoryDto = _mapper.Map<SkillHistoryDto>(skillHistory);
                return ServiceResponse<SkillHistoryDto>.SuccessResult(skillHistoryDto, 200, "Skill history retrieved successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<SkillHistoryDto>.Failure(ex.Message, ex.Code ?? AppSkillHistoryService.GENERAL_SKILL_HISTORY_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillHistoryDto>.Failure($"Failed to retrieve skill history: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<SkillHistoryLookupDto>>> GetLookupAsync()
        {
            try
            {
                var skillHistories = await _skillHistoryRepository.GetAllAsync(); // Only active skill histories
                var lookupDtos = _mapper.Map<List<SkillHistoryLookupDto>>(skillHistories);
                return ServiceResponse<List<SkillHistoryLookupDto>>.SuccessResult(lookupDtos, 200, "Skill history lookup retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillHistoryLookupDto>>.Failure($"Failed to retrieve skill history lookup: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<List<SkillHistoryLookupDto>>> GetLookUpByUserIdAsync(Guid userId)
        {
            try
            {
                if (userId == Guid.Empty)
                {
                    return ServiceResponse<List<SkillHistoryLookupDto>>.Failure("User ID cannot be empty.", 400);
                }

                var skillHistoriesWithDetails = await _skillHistoryRepository.WithDetailsAsync();
                var skillHistories = await skillHistoriesWithDetails
                    .Where(sh => sh.UserId == userId && !sh.IsDeleted)
                    .ToListAsync();
                var lookupDtos = _mapper.Map<List<SkillHistoryLookupDto>>(skillHistories);
                return ServiceResponse<List<SkillHistoryLookupDto>>.SuccessResult(lookupDtos, 200, "Skill history lookup by user retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillHistoryLookupDto>>.Failure($"Failed to retrieve skill history lookup by user: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<SkillHistoryPagedResultDto>> GetPagedListAsync(SkillHistoryFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    return ServiceResponse<SkillHistoryPagedResultDto>.Failure("Filter input cannot be null.", 400);
                }

                var query = await _skillHistoryRepository.WithDetailsAsync();

                // Apply filters
                if (input.UserId.HasValue)
                {
                    query = query.Where(sh => sh.UserId == input.UserId.Value);
                }
                if (!string.IsNullOrWhiteSpace(input.CoreSkillName))
                {
                    query = query.Where(sh => sh.CoreSkillName.Contains(input.CoreSkillName));
                }
                if (!string.IsNullOrWhiteSpace(input.Comment))
                {
                    query = query.Where(sh => sh.Comment != null && sh.Comment.Contains(input.Comment));
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(sh => sh.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(sh => sh.CreationTime <= input.CreationTimeEnd.Value);
                }
                if (input.LastModificationTimeStart.HasValue)
                {
                    query = query.Where(sh => sh.LastModificationTime >= input.LastModificationTimeStart.Value);
                }
                if (input.LastModificationTimeEnd.HasValue)
                {
                    query = query.Where(sh => sh.LastModificationTime <= input.LastModificationTimeEnd.Value);
                }
                query = query.Where(sh => !sh.IsDeleted); // Default to active skill histories

                // Apply sorting
                if (!string.IsNullOrWhiteSpace(input.Sorting))
                {
                    var sortParts = input.Sorting.Trim().Split(' ');
                    var propertyName = sortParts[0];
                    var isDescending = sortParts.Length > 1 && sortParts[1].ToUpper() == "DESC";

                    switch (propertyName.ToLower())
                    {
                        case "coreskillname":
                            query = isDescending ? query.OrderByDescending(sh => sh.CoreSkillName) : query.OrderBy(sh => sh.CoreSkillName);
                            break;
                        case "changedproficiencylevel":
                            query = isDescending ? query.OrderByDescending(sh => sh.ChangedProficiencyLevel) : query.OrderBy(sh => sh.ChangedProficiencyLevel);
                            break;
                        case "comment":
                            query = isDescending ? query.OrderByDescending(sh => sh.Comment) : query.OrderBy(sh => sh.Comment);
                            break;
                        case "creationtime":
                            query = isDescending ? query.OrderByDescending(sh => sh.CreationTime) : query.OrderBy(sh => sh.CreationTime);
                            break;
                        case "lastmodificationtime":
                            query = isDescending ? query.OrderByDescending(sh => sh.LastModificationTime) : query.OrderBy(sh => sh.LastModificationTime);
                            break;
                        default:
                            query = query.OrderBy(sh => sh.CoreSkillName); // Default sorting
                            break;
                    }
                }
                else
                {
                    query = query.OrderBy(sh => sh.CoreSkillName); // Default sorting
                }

                // Apply pagination
                var totalCount = await query.LongCountAsync();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<SkillHistoryDto>>(items);

                var result = new SkillHistoryPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<SkillHistoryPagedResultDto>.SuccessResult(result, 200, "Paged skill histories retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillHistoryPagedResultDto>.Failure($"Failed to retrieve paged skill histories: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill history ID cannot be empty.", 400);
                }

                await _skillHistoryRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill history permanently deleted successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillHistoryService.GENERAL_SKILL_HISTORY_EXCEPTION_CODE, 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to permanently delete skill history: {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse> RestoreSkillHistoryAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return ServiceResponse.Failure("Skill history ID cannot be empty.", 400);
                }

                await _skillHistoryRepository.RestoreSkillHistoryAsync(id);
                return ServiceResponse.SuccessResult(200, "Skill history restored successfully.");
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, ex.Code ?? AppSkillHistoryService.GENERAL_SKILL_HISTORY_EXCEPTION_CODE, ex.Code == SkillMatrixManagementDomainErrorCodes.SkillHistory.SKILL_HISTORY_NOT_DELETED ? 400 : 404);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure($"Failed to restore skill history: {ex.Message}", 500);
            }
        }

        private async Task<int> CalculateUserIdBasedVersion(Guid userId)
        {
            var skillHistories = await _skillHistoryRepository.WithDetailsAsync();
            return await skillHistories
                .Where(sh => sh.UserId == userId && !sh.IsDeleted)
                .CountAsync() + 1;
        }
    }
}