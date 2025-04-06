using Microsoft.AspNetCore.Mvc;

namespace ToDoApiAssignment.Api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected ActionResult SafeExecute<T>(Func<T> action)
        {
            try
            {
                var result = action();
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });  
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        protected IActionResult SafeDeleteExecute(Action action)
        {
            try
            {
                action();
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
