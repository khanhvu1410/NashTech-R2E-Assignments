using Microsoft.AspNetCore.Mvc;

namespace ToDoApiAssignment.Api.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected ActionResult SafeExecute<T>(Func<T> action)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var result = action();
                return Ok(result);
            });
        }

        protected IActionResult SafeDeleteExecute(Action action)
        {
            return ExecuteWithErrorHandling(() =>
            {
                action();
                return NoContent();
            });
        }

        private ActionResult ExecuteWithErrorHandling(Func<ActionResult> action)
        {
            try
            {
                return action();
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
