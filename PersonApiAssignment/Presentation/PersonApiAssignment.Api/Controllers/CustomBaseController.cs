using Microsoft.AspNetCore.Mvc;

namespace PersonApiAssignment.Api.Controllers
{
    public class CustomBaseController : ControllerBase
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
                return StatusCode(500, new 
                { 
                    message = "An unexpected error occured.", 
                    detail = ex.Message 
                });
            }
        }
    }
}
