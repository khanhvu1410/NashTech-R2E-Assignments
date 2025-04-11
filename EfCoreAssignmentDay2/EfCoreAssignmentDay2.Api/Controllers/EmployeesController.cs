using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : CustomBaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeToAddDTO employeeDto)
        {
            try
            {
                var employee = await _employeeService.AddEmployeeAsync(employeeDto);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
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
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            return await SafeExecute(async () =>
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                return employee;
            });
        }

        [HttpPut]
        public async Task<ActionResult<DepartmentDTO>> UpdateEmployee(EmployeeDTO employeeDto)
        {
            return await SafeExecute(async () =>
            {
                var employee = await _employeeService.UpdateEmployeeAsync(employeeDto);
                return employee;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await SafeDeleteExecute(async () =>
            {
                await _employeeService.DeleteEmployeeAsync(id);
            });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllEmployeesWithDepartmentNames()
        {
            var employees = await _employeeService.GetAllEmployeesWithDepartmentNames();
            return Ok(employees);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllEmployeesWithProjects()
        {
            var employees = await _employeeService.GetAllEmployeesWithProjectsAsync();
            return Ok(employees);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllEmployeesWithAndJoindedDateAsync()
        {
            var employees = await _employeeService.GetAllEmployeesWithAndJoindedDateAsync();
            return Ok(employees);
        }
    }
}
