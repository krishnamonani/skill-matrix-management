using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using SkillMatrixManagement.DTOs.SkillGapDTO;
using SkillMatrixManagement.DTOs.UserDTO;
using SkillMatrixManagement.DTOs.XlsxDTO;
using SkillMatrixManagement.Repositories;
using Volo.Abp.Application.Services;

namespace SkillMatrixManagement.Services
{
    public class AppXLSXService : ApplicationService, IXLSXService
    {
        private readonly IUserService _userService;
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ISkillSubtopicRepository _skillSubtopicRepository;
        private readonly IEmployeeSkillRepository _employeeSkillRepository;

        public AppXLSXService(
            IUserService userService,
            IProjectRepository projectRepository,
            IProjectEmployeeRepository projectEmployeeRepository,
            ISkillRepository skillRepository,
            ISkillSubtopicRepository skillSubtopicRepository,
            IEmployeeSkillRepository employeeSkillRepository)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _projectEmployeeRepository = projectEmployeeRepository ?? throw new ArgumentNullException(nameof(projectEmployeeRepository));
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _skillSubtopicRepository = skillSubtopicRepository ?? throw new ArgumentNullException(nameof(skillSubtopicRepository));
            _employeeSkillRepository = employeeSkillRepository ?? throw new ArgumentNullException(nameof(employeeSkillRepository));
        }

        // Generate Excel for all employees
        public async Task<(MemoryStream, string)> GenerateAllEmployeesExcelAsync()
        {
            try
            {
                var response = await _userService.GetAllAsync(includeDeleted: false);
                if (!response.Success || response.Data == null)
                {
                    throw new Exception(response.ErrorMessage ?? "Failed to retrieve employees");
                }
                var employees = response.Data;

                // Create a list of employee-project pairs
                var employeeProjectPairs = new List<(UserDto Employee, string Project)>();
                foreach (var employee in employees)
                {
                    var projects = await GetEmployeeProjectNamesByUserIdAsync(employee.Id);
                    if (projects?.ProjectNames != null && projects.ProjectNames.Any())
                    {
                        foreach (var projectName in projects.ProjectNames)
                        {
                            employeeProjectPairs.Add((employee, projectName));
                        }
                    }
                    else
                    {
                        employeeProjectPairs.Add((employee, "N/A"));
                    }
                }

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("All Employees");

                // Headers
                worksheet.Cell(1, 1).Value = "First Name";
                worksheet.Cell(1, 2).Value = "Last Name";
                worksheet.Cell(1, 3).Value = "Email";
                worksheet.Cell(1, 4).Value = "Username";
                worksheet.Cell(1, 5).Value = "Experience (Years)";
                worksheet.Cell(1, 6).Value = "Phone Number";
                worksheet.Cell(1, 7).Value = "Role";
                worksheet.Cell(1, 8).Value = "Department";
                worksheet.Cell(1, 9).Value = "Skills";
                worksheet.Cell(1, 10).Value = "Project";
                worksheet.Cell(1, 11).Value = "Availability";

                // Data
                for (int i = 0; i < employeeProjectPairs.Count; i++)
                {
                    var (employee, projectName) = employeeProjectPairs[i];
                    var skills = await GetEmployeeSkillByUserIdAsync(employee.Id);

                    worksheet.Cell(i + 2, 1).Value = employee.FirstName;
                    worksheet.Cell(i + 2, 2).Value = employee.LastName;
                    worksheet.Cell(i + 2, 3).Value = employee.Email;
                    worksheet.Cell(i + 2, 4).Value = employee.UserName;
                    worksheet.Cell(i + 2, 5).Value = employee.Experience;
                    worksheet.Cell(i + 2, 6).Value = employee.PhoneNumber;
                    worksheet.Cell(i + 2, 7).Value = employee.Role?.Name.ToString() ?? "N/A";
                    worksheet.Cell(i + 2, 8).Value = employee.Department?.Name ?? "N/A";
                    worksheet.Cell(i + 2, 9).Value = skills?.Skills != null ? string.Join(", ", skills.Skills) : "N/A";
                    worksheet.Cell(i + 2, 10).Value = projectName;
                    worksheet.Cell(i + 2, 11).Value = employee.IsAvailable.ToString();
                }

                // Auto-adjust columns
                worksheet.Columns().AdjustToContents();

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0; // Reset stream position for reading
                return (stream, "AllEmployees.xlsx");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to generate Excel: {ex.Message}", ex);
            }
        }

        // Generate Excel for employees in a specific project
        public async Task<(MemoryStream, string)> GenerateProjectEmployeesExcelAsync(Guid projectId)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(projectId);
                if (project == null)
                {
                    throw new Exception("Project not found");
                }

                var employeeIds = await GetEmployeesByProjectIdAsync(projectId);
                if (employeeIds == null || !employeeIds.Any())
                {
                    throw new Exception("No employees found for this project");
                }

                var response = await _userService.GetAllAsync(includeDeleted: false);
                if (!response.Success || response.Data == null)
                {
                    throw new Exception(response.ErrorMessage ?? "Failed to retrieve employees");
                }
                var projectEmployees = response.Data.Where(e => employeeIds.Contains(e.Id)).ToList();

                // Create a list of employee-project pairs (one project per row)
                var employeeProjectPairs = new List<(UserDto Employee, string Project)>();
                foreach (var employee in projectEmployees)
                {
                    var projects = await GetEmployeeProjectNamesByUserIdAsync(employee.Id);
                    var projectNames = projects?.ProjectNames?.Where(p => p == project.ProjectName).ToList();
                    if (projectNames != null && projectNames.Any())
                    {
                        foreach (var projectName in projectNames)
                        {
                            employeeProjectPairs.Add((employee, projectName));
                        }
                    }
                    else
                    {
                        employeeProjectPairs.Add((employee, project.ProjectName));
                    }
                }

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add($"{project.ProjectName} Employees");

                // Headers
                worksheet.Cell(1, 1).Value = "First Name";
                worksheet.Cell(1, 2).Value = "Last Name";
                worksheet.Cell(1, 3).Value = "Email";
                worksheet.Cell(1, 4).Value = "Username";
                worksheet.Cell(1, 5).Value = "Experience (Years)";
                worksheet.Cell(1, 6).Value = "Phone Number";
                worksheet.Cell(1, 7).Value = "Role";
                worksheet.Cell(1, 8).Value = "Department";
                worksheet.Cell(1, 9).Value = "Skills";
                worksheet.Cell(1, 10).Value = "Project";
                worksheet.Cell(1, 11).Value = "Availability";

                // Data
                for (int i = 0; i < employeeProjectPairs.Count; i++)
                {
                    var (employee, projectName) = employeeProjectPairs[i];
                    var skills = await GetEmployeeSkillByUserIdAsync(employee.Id);

                    worksheet.Cell(i + 2, 1).Value = employee.FirstName;
                    worksheet.Cell(i + 2, 2).Value = employee.LastName;
                    worksheet.Cell(i + 2, 3).Value = employee.Email;
                    worksheet.Cell(i + 2, 4).Value = employee.UserName;
                    worksheet.Cell(i + 2, 5).Value = employee.Experience;
                    worksheet.Cell(i + 2, 6).Value = employee.PhoneNumber;
                    worksheet.Cell(i + 2, 7).Value = employee.Role?.Name.ToString() ?? "N/A";
                    worksheet.Cell(i + 2, 8).Value = employee.Department?.Name ?? "N/A";
                    worksheet.Cell(i + 2, 9).Value = skills?.Skills != null ? string.Join(", ", skills.Skills) : "N/A";
                    worksheet.Cell(i + 2, 10).Value = projectName;
                    worksheet.Cell(i + 2, 11).Value = employee.IsAvailable.ToString();
                }

                // Auto-adjust columns
                worksheet.Columns().AdjustToContents();

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0; // Reset stream position for reading
                return (stream, $"{project.ProjectName}_Employees.xlsx");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to generate project Excel: {ex.Message}", ex);
            }
        }

        // Generate Excel for a specific employee
        public async Task<(MemoryStream, string)> GenerateEmployeeExcelAsync(Guid userId)
        {
            try
            {
                var response = await _userService.GetByIdAsync(userId);
                if (!response.Success || response.Data == null)
                {
                    throw new Exception(response.ErrorMessage ?? "Employee not found");
                }
                var employee = response.Data;

                var skills = await GetEmployeeSkillByUserIdAsync(userId);
                var projects = await GetEmployeeProjectNamesByUserIdAsync(userId);

                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add($"{employee.FirstName} {employee.LastName}");

                // Headers and Data
                worksheet.Cell(1, 1).Value = "Field";
                worksheet.Cell(1, 2).Value = "Value";

                worksheet.Cell(2, 1).Value = "First Name";
                worksheet.Cell(2, 2).Value = employee.FirstName;

                worksheet.Cell(3, 1).Value = "Last Name";
                worksheet.Cell(3, 2).Value = employee.LastName;

                worksheet.Cell(4, 1).Value = "Email";
                worksheet.Cell(4, 2).Value = employee.Email;

                worksheet.Cell(5, 1).Value = "Username";
                worksheet.Cell(5, 2).Value = employee.UserName;

                worksheet.Cell(6, 1).Value = "Experience (Years)";
                worksheet.Cell(6, 2).Value = employee.Experience;

                worksheet.Cell(7, 1).Value = "Phone Number";
                worksheet.Cell(7, 2).Value = employee.PhoneNumber;

                worksheet.Cell(8, 1).Value = "Role";
                worksheet.Cell(8, 2).Value = employee.Role?.Name.ToString() ?? "N/A";

                worksheet.Cell(9, 1).Value = "Department";
                worksheet.Cell(9, 2).Value = employee.Department?.Name ?? "N/A";

                worksheet.Cell(10, 1).Value = "Skills";
                worksheet.Cell(10, 2).Value = skills?.Skills != null ? string.Join(", ", skills.Skills) : "N/A";

                worksheet.Cell(11, 1).Value = "Projects";
                worksheet.Cell(11, 2).Value = projects?.ProjectNames != null ? string.Join(", ", projects.ProjectNames) : "N/A";

                worksheet.Cell(12, 1).Value = "Availability";
                worksheet.Cell(12, 2).Value = employee.IsAvailable.ToString();

                // Auto-adjust columns
                worksheet.Columns().AdjustToContents();

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0; // Reset stream position for reading
                return (stream, $"{employee.FirstName}_{employee.LastName}_Details.xlsx");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to generate employee Excel: {ex.Message}", ex);
            }
        }

        // Helper methods (unchanged)
        private async Task<EmployeeProjectDto> GetEmployeeProjectNamesByUserIdAsync(Guid userId)
        {
            try
            {
                var filteredProjectIdsByUserId = (await _projectEmployeeRepository.GetAllAsync())
                    .Where(project => project.UserId == userId)
                    .Select(project => project.ProjectId)
                    .ToList();
                var projects = await _projectRepository.GetAllAsync();

                var projectNames = new List<string>();
                foreach (var id in filteredProjectIdsByUserId)
                {
                    if (id == Guid.Empty) continue;
                    var project = projects.FirstOrDefault(p => p.Id == id);
                    if (project == null) continue;
                    projectNames.Add(project.ProjectName);
                }

                return new EmployeeProjectDto()
                {
                    ProjectNames = projectNames,
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<EmployeeSkillDto> GetEmployeeSkillByUserIdAsync(Guid userId)
        {
            try
            {
                var response = await _userService.GetByIdAsync(userId);
                if (!response.Success || response.Data == null)
                {
                    return null;
                }

                var employeeDetails = (await _employeeSkillRepository.GetAllAsync())
                    .Where(u => u.UserId == userId).ToList();

                var employeeSkills = employeeDetails
                    .Select(u => u.CoreSkillName)
                    .ToList();

                var employeeSkillDto = new EmployeeSkillDto()
                {
                    Skills = employeeSkills,
                };
                return employeeSkillDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<List<Guid>> GetEmployeesByProjectIdAsync(Guid projectId)
        {
            try
            {
                var employeeIdsWithParticularProject = (await _projectEmployeeRepository.GetAllAsync())
                    .Where(project => project.ProjectId == projectId)
                    .Select(project => project.UserId)
                    .ToList();

                return employeeIdsWithParticularProject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}