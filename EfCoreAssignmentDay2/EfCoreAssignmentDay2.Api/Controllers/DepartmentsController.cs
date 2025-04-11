using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentsController : CustomBaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDTO>> CreateDepartment(DepartmentToAddDTO departmentDto)
        {
            var department = await _departmentService.AddDepartmentAsync(departmentDto);
            
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentById(int id)
        {
            return await SafeExecute(async () =>
            {
                var department = await _departmentService.GetDepartmentByIdAsync(id);
                return department;
            });
        }

        [HttpPut]
        public async Task<ActionResult<DepartmentDTO>> UpdateDepartment(DepartmentDTO departmentDto)
        {
            return await SafeExecute(async () =>
            {
                var department = await _departmentService.UpdateDepartmentAsync(departmentDto);
                return department;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return await SafeDeleteExecute(async () =>
            {
                await _departmentService.DeleteDepartmentAsync(id);
            });
        }
    }
}
