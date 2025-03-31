using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillMatrixManagement.DTOs.EmployeeSkillDTO;
using SkillMatrixManagement.DTOs.Shared;
using SkillMatrixManagement.DTOs.SkillSubtopicDTO;
using SkillMatrixManagement.Models;
using SkillMatrixManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;

namespace SkillMatrixManagement.Services
{
    public class AppEmployeeSkillService:ApplicationService, IEmployeeSkillService
    {

        private readonly IEmployeeSkillRepository _employeeSkillRepository;
        private readonly IMapper _mapper;

        public AppEmployeeSkillService(IEmployeeSkillRepository mployeeSkillRepository, IMapper mapper)
        {
            _employeeSkillRepository = mployeeSkillRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<int>> CountAsync(bool includeDeleted = false)
        {
            try
            {
                var query = await _employeeSkillRepository.WithDetailsAsync();
                if (!includeDeleted)
                {
                    query = query.Where(r => !r.IsDeleted);
                }
                var count = query.Count();
                return ServiceResponse<int>.SuccessResult(count, 200);
            }
            catch (Exception ex)
            {
                return ServiceResponse<int>.Failure($"Failed to retrieve count: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse<EmployeeSkillDto>> CreateAsync(CreateEmployeeSkillDto input)
        {
            try
            {

                var EmployeeSkill = new EmployeeSkill()
                {
                    UserId = input.UserId,
                    CoreSkillName = input.CoreSkillName,
                    SelfAssessedProficiency = input.SelfAssessedProficiency,
                    ManagerAssignedProficiency = input.ManagerAssignedProficiency,
                    EndorsedAt = input.EndorsedAt,
                    EndorsedBy = input.EndorsedBy,
                    //SkillDescription = input.SkillDescription
                };
            EmployeeSkill= await _employeeSkillRepository.CreateAsync(EmployeeSkill);
            var res= _mapper.Map<EmployeeSkillDto>(EmployeeSkill);
            return ServiceResponse<EmployeeSkillDto>.SuccessResult(res, 201);
            }
            catch(BusinessException ex)
            {
                return ServiceResponse<EmployeeSkillDto>.Failure(ex.Message, 400);

            }
            catch (Exception ex)
            {
                return ServiceResponse<EmployeeSkillDto>.Failure(ex.Message, 500);

            }


        }


        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {

            try
            {
                await _employeeSkillRepository.DeleteAsync(id);
                return ServiceResponse.SuccessResult(200);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
        }

        public async Task<ServiceResponse<List<EmployeeSkillDto>>> GetAllAsync(bool includeDeleted = false)
        {
            try
            {

            var skills = await _employeeSkillRepository.GetListAsync();
            if (skills == null)
            {
                return ServiceResponse<List<EmployeeSkillDto>>.Failure("No Employee Skill Exist!", 400);
            }
            return ServiceResponse<List<EmployeeSkillDto>>.SuccessResult( _mapper.Map<List<EmployeeSkillDto>>(skills), 200);
            
            }
            catch(BusinessException ex)
            {
                return ServiceResponse<List<EmployeeSkillDto>>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<EmployeeSkillDto>>.Failure(ex.Message, 400);
            }

        }

        public async Task<ServiceResponse<EmployeeSkillDto>> GetByIdAsync(Guid id)
        {
            try
            {

            return ServiceResponse<EmployeeSkillDto>.SuccessResult(_mapper.Map<EmployeeSkillDto>(_employeeSkillRepository.GetByIdAsync(id)), 201);
            }
            catch(BusinessException ex)
            {
                return ServiceResponse<EmployeeSkillDto>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<EmployeeSkillDto>.Failure(ex.Message, 500);

            }


        }

        public async Task<ServiceResponse<List<EmployeeSkillLookupDto>>> GetLookupAsync()
        {
            try
            {

                var skills = await _employeeSkillRepository.GetListAsync();
                if (skills == null)
                {
                    return ServiceResponse<List<EmployeeSkillLookupDto>>.Failure("No Employee Skill Exist!", 201);
                }
                return ServiceResponse<List<EmployeeSkillLookupDto>>.SuccessResult(_mapper.Map<List<EmployeeSkillLookupDto>>(skills), 201);

            }
            catch (BusinessException ex)
            {
                return ServiceResponse<List<EmployeeSkillLookupDto>>.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<EmployeeSkillLookupDto>>.Failure(ex.Message, 400);
            }
        }

        public async Task<ServiceResponse<EmployeeSkillPagedResultDto>> GetPagedListAsync(EmployeeSkillFilterDto input)
        {
            try
            {
                if (input == null)
                {
                    throw new UserFriendlyException("Filter input cannot be null.");
                }

                var query = await _employeeSkillRepository.WithDetailsAsync();

                // Apply filters
                if (input.UserId.HasValue)
                {
                    query = query.Where(s => s.UserId == input.UserId.Value);
                }
               
                if (input.IsDeleted.HasValue)
                {
                    query = query.Where(s => s.IsDeleted == input.IsDeleted.Value);
                }
                else
                {
                    query = query.Where(s => !s.IsDeleted);
                }
                if (input.CreationTimeStart.HasValue)
                {
                    query = query.Where(s => s.CreationTime >= input.CreationTimeStart.Value);
                }
                if (input.CreationTimeEnd.HasValue)
                {
                    query = query.Where(s => s.CreationTime <= input.CreationTimeEnd.Value);
                }

                // Apply sorting
                query = query.OrderBy(s => s.CreationTime);

                // Apply pagination
                var totalCount = query.LongCount();
                var items = await query.Skip(input.SkipCount).Take(input.MaxResultCount).ToListAsync();
                var itemDtos = _mapper.Map<List<EmployeeSkillDto>>(items);

                var result = new EmployeeSkillPagedResultDto(totalCount, itemDtos);
                return ServiceResponse<EmployeeSkillPagedResultDto>.SuccessResult(result, 200, "Paged employee skills retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResponse<EmployeeSkillPagedResultDto>.Failure($"Failed to retrieve paged employee skills: {ex.Message}", 400);
            }
        }

        public async Task<ServiceResponse> PermanentDeleteAsync(Guid id)
        {
            try
            {
                await _employeeSkillRepository.PermanentDeleteAsync(id);
                return ServiceResponse.SuccessResult(200);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
        }

        public async Task<ServiceResponse> RestoreEmployeeSkillAsync(Guid id)
        {

            try
            {
                await _employeeSkillRepository.RestoreEmployeeSkillAsync(id); ;
                return ServiceResponse.SuccessResult(200);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }

        }

        public async Task<ServiceResponse> UpdateAsync(Guid id, UpdateEmployeeSkillDto input)
        {
            try
            {
                var existingEmployeeSkill = await _employeeSkillRepository.GetAsync(id);
                if (existingEmployeeSkill == null)
                {
                    return ServiceResponse.Failure("EmployeeSkill not found", 404);
                }


                _mapper.Map(input, existingEmployeeSkill);

                // Save changes
                await _employeeSkillRepository.UpdateAsync(existingEmployeeSkill);

                return ServiceResponse.SuccessResult(200);
            }
            catch (BusinessException ex)
            {
                return ServiceResponse.Failure(ex.Message, 400);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message, 500);
            }
           
        }
    }
}
