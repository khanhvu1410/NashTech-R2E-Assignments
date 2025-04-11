using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectEmployeesController : CustomBaseController
    {
        private readonly IProjectEmployeeService _projectEmployeeService;

        public ProjectEmployeesController(IProjectEmployeeService projectEmployeeService)
        {
            _projectEmployeeService = projectEmployeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateProjectEmployee(ProjectEmployeeDTO projectEmployeeDto)
        {
            try
            {
                var projectEmployee = await _projectEmployeeService.AddProjectEmployeeAsync(projectEmployeeDto);
                return CreatedAtAction(nameof(GetProjectEmployeeByIds), new { projectId = projectEmployeeDto.ProjectId, employeeId = projectEmployeeDto.EmployeeId }, projectEmployee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "An unexpected error occured.",
                    detail = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllProjectEmployees()
        {
            var projectEmployees = await _projectEmployeeService.GetAllProjectEmployeesAsync();
            return Ok(projectEmployees);
        }

        [HttpGet("{projectId}&{employeeId}")]
        public async Task<ActionResult<EmployeeDTO>> GetProjectEmployeeByIds(int projectId, int employeeId)
        {
            return await SafeExecute(async () =>
            {
                var projectEmployee = await _projectEmployeeService.GetProjectEmployeeByIdAsync(projectId, employeeId);
                return projectEmployee;
            });
        }

        [HttpPut]
        public async Task<ActionResult<DepartmentDTO>> UpdateProjectEmployee(ProjectEmployeeDTO projectEmployeeDto)
        {
            return await SafeExecute(async () =>
            {
                var employee = await _projectEmployeeService.UpdateProjectEmployeeAsync(projectEmployeeDto);
                return employee;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProjectEmployee(int projectId, int employeeId)
        {
            return await SafeDeleteExecute(async () =>
            {
                await _projectEmployeeService.DeleteProjectEmployeeAsync(projectId, employeeId);
            });
        }
    }
}
