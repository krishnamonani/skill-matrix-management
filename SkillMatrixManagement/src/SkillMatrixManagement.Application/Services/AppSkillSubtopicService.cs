using AutoMapper;
using AutoMapper.Internal.Mappers;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillSubtopicDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppSkillSubtopicService:ApplicationService, ISkillSubtopicService
    {
        private readonly ISkillSubtopicRepository _skillSubtopicRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IMapper _mapper;

        public AppSkillSubtopicService(ISkillSubtopicRepository skillSubtopicRepository, IEmployeeSkillRepository employeeSkillRepository, IMapper mapper)
        {
            _skillSubtopicRepository = skillSubtopicRepository;
            _employeeSkillRepository = employeeSkillRepository;
            _mapper = mapper;
        }

        public Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<SkillSubtopicDto>> CreateAsync(CreateSkillSubtopicDto input)
        {
            try
            {
                var skillSubtopic = _mapper.Map<SkillSubtopic>(input);
                skillSubtopic.IsDeleted = false;
                var createdEntity = await _skillSubtopicRepository.CreateAsync(skillSubtopic);
                var dto = _mapper.Map<SkillSubtopicDto>(createdEntity);

                return ServiceResponse<SkillSubtopicDto>.SuccessResult(dto, 201);
            }
            catch (BusinessException ex)
            {

                return ServiceResponse<SkillSubtopicDto>.Failure(ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillSubtopicDto>.Failure(ex.Message,500);
            }

        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            try
            {
                await _skillSubtopicRepository.SoftDeleteAsync(id);
                return ServiceResponse.SuccessResult(200);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Code, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message,500);

            }
            
        }

        public async Task<ServiceResponse<List<SkillSubtopicDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {
                if (includeDeleted)
                {

                var entities = await _skillSubtopicRepository.GetAllAsync();
                var dtoList = _mapper.Map<List<SkillSubtopicDto>>(entities);

                return ServiceResponse<List<SkillSubtopicDto>>.SuccessResult(dtoList, 201);
                }

                else
                {
                    var entities = await _skillSubtopicRepository.GetAllAsync();
                    entities = entities.Where(e => e.IsDeleted == false).ToList();
                    var dtoList = _mapper.Map<List<SkillSubtopicDto>>(entities);

                    return ServiceResponse<List<SkillSubtopicDto>>.SuccessResult(dtoList,200);
                }

            }
            catch (BusinessException ex)
            {
                return ServiceResponse<List<SkillSubtopicDto>>.Failure(ex.Code,400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<SkillSubtopicDto>>.Failure(ex.Message,500);
            }
        }

        public async Task<ServiceResponse<SkillSubtopicDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await _skillSubtopicRepository.GetByIdAsync(id);
                var dto = _mapper.Map<SkillSubtopicDto>(entity);

                return ServiceResponse<SkillSubtopicDto>.SuccessResult(dto,201);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse<SkillSubtopicDto>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SkillSubtopicDto>.Failure(ex.Message, 500);
            }
        }

        public async Task<ServiceResponse<List<SkillSubtopicLookupDto>>> GetLookupAsync()
        {
            try
            {
                var entities = await _skillSubtopicRepository.GetAllAsync();
                var filteredEntities = entities.Where(e => !e.IsDeleted).ToList();
                var lookupDtos = ObjectMapper.Map<List<SkillSubtopic>, List<SkillSubtopicLookupDto>>(filteredEntities);
                return ServiceResponse<List<SkillSubtopicLookupDto>>.SuccessResult(lookupDtos,200);
            }
            catch(BusinessException ex)
            {
                return ServiceResponse<List<SkillSubtopicLookupDto>>.Failure(ex.Code,400);
            }

            catch (Exception ex)
            {
                return ServiceResponse<List<SkillSubtopicLookupDto>>.Failure(ex.Message, 500);
            }
        }

        public Task<ServiceResponse<SkillSubtopicPagedResultDto>> GetPagedListAsync(SkillSubtopicFilterDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                await _skillSubtopicRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200);
            }
            catch(BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Code,400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
        }


        public async Task<ServiceResponse> RestoreSkillSubtopicAsync(Guid id)
        {
            try
            {
                await _skillSubtopicRepository.RestoreSkillSubtopicAsync(id);
                return ServiceResponse.SuccessResult(200);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message,500);
            }
        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateSkillSubtopicDto input)
        {
            try
            {

                var skillSubtopic = _mapper.Map<SkillSubtopic>(input);
                await _skillSubtopicRepository.UpdateAsync(skillSubtopic);
                return ServiceResponse.SuccessResult(200);
            }
            catch(Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
        }

        public async Task<ServiceResponse<HashSet<string>>> GetSkillSetAsync()
        {
            try
            {
                var set = new HashSet<string>();
                var skillDetails = (await _skillSubtopicRepository.GetAllAsync())
                    .Select(s => s.Description)
                    .ToList();

                foreach (var skills in skillDetails)
                {
                    if (skills == null) continue;
                    foreach (var kvp in skills)
                    {
                        set.Add(kvp.Key);
                    }
                }

                return ServiceResponse<HashSet<string>>.SuccessResult(set, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<HashSet<string>>.Failure($"Something went wrong while fetching the skills, {ex.Message}", 500);
            }
        }

        public async Task<ServiceResponse<HashSet<string>>> GetSkillSetBasedOnEmployeeSkillAsync(Guid userId)
        {

            try
            {
                var employeeSkills = (await _employeeSkillRepository.GetAllAsync())
                .Where(es => es.UserId == userId).Select(user => user.CoreSkillName.ToLower().Trim()).ToList();

                var set = new HashSet<string>();
                var skillDetails = (await _skillSubtopicRepository.GetAllAsync())
                    .Select(s => s.Description)
                    .ToList();

                foreach (var skills in skillDetails)
                {
                    if (skills == null) continue;
                    foreach (var kvp in skills)
                    {
                        var key = kvp.Key;
                        if (key == null) continue;
                        if (!employeeSkills.Contains(key.ToLower()))
                        {
                            set.Add(key.Trim());
                        }
                    }
                }

                return ServiceResponse<HashSet<string>>.SuccessResult(set, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<HashSet<string>>.Failure($"Something went wrong while fetching the skills, {ex.Message}", 500);
            }

        }
    }
}
