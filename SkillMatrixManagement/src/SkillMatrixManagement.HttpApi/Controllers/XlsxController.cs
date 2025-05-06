using Microsoft.AspNetCore.Mvc;
using SkillMatrixManagement.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SkillMatrixManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlsxController : ControllerBase
    {
        private readonly IXLSXService _xlsxService;

        public XlsxController(IXLSXService xlsxService)
        {
            _xlsxService = xlsxService ?? throw new ArgumentNullException(nameof(xlsxService));
        }

        [HttpGet("all-employees")]
        public async Task<IActionResult> GetAllEmployeesExcel()
        {
            try
            {
                var (stream, fileName) = await _xlsxService.GenerateAllEmployeesExcelAsync();
                return File(
                    fileStream: stream,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: fileName,
                    enableRangeProcessing: true
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"Failed to generate Excel: {ex.Message}" });
            }
        }

        [HttpGet("project-employees/{projectId}")]
        public async Task<IActionResult> GetProjectEmployeesExcel(Guid projectId)
        {
            if (projectId == Guid.Empty)
            {
                return BadRequest(new { ErrorMessage = "Invalid project ID." });
            }

            try
            {
                var (stream, fileName) = await _xlsxService.GenerateProjectEmployeesExcelAsync(projectId);
                return File(
                    fileStream: stream,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: fileName,
                    enableRangeProcessing: true
                );
            }
            catch (Exception ex) when (ex.Message.Contains("not found"))
            {
                return NotFound(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"Failed to generate project Excel: {ex.Message}" });
            }
        }

        [HttpGet("employee/{userId}")]
        public async Task<IActionResult> GetEmployeeExcel(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(new { ErrorMessage = "Invalid user ID." });
            }

            try
            {
                var (stream, fileName) = await _xlsxService.GenerateEmployeeExcelAsync(userId);
                return File(
                    fileStream: stream,
                    contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    fileDownloadName: fileName,
                    enableRangeProcessing: true
                );
            }
            catch (Exception ex) when (ex.Message.Contains("not found"))
            {
                return NotFound(new { ErrorMessage = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"Failed to generate employee Excel: {ex.Message}" });
            }
        }
    }
}