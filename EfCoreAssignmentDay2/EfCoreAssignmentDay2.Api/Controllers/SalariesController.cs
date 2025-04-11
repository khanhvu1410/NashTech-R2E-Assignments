using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalariesController : CustomBaseController
    {
        private readonly ISalaryService _salariesService;

        public SalariesController(ISalaryService salariesService)
        {
            _salariesService = salariesService;
        }

        [HttpPost]
        public async Task<ActionResult<SalariesDTO>> CreateSalaries(SalariesToAddDTO salariesDto)
        {
            try
            {
                var salaries = await _salariesService.AddSalariesAsync(salariesDto);
                return CreatedAtAction(nameof(GetSalariesById), new { id = salaries.Id }, salaries);
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
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllSalaries()
        {
            var salaries = await _salariesService.GetAllSalariesAsync();
            return Ok(salaries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalariesDTO>> GetSalariesById(int id)
        {
            return await SafeExecute(async () =>
            {
                var salaries = await _salariesService.GetSalariesByIdAsync(id);
                return salaries;
            });
        }

        [HttpPut]
        public async Task<ActionResult<SalariesDTO>> UpdateSalaries(SalariesDTO salariesDto)
        {
            return await SafeExecute(async () =>
            {
                var salaries = await _salariesService.UpdateSalariesAsync(salariesDto);
                return salaries;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSalaries(int id)
        {
            return await SafeDeleteExecute(async () =>
            {
                await _salariesService.DeleteSalariesAsync(id);
            });
        }
    }
}
