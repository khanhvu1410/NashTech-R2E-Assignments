using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        protected async Task<ActionResult> SafeExecute<T>(Func<Task<T>> action)
        {
            return await ExecuteWithErrorHandling( async () =>
            {
                var result = await action();
                return Ok(result);
            });
        }

        protected async Task<IActionResult> SafeDeleteExecute(Func<Task> action)
        {
            return await ExecuteWithErrorHandling(async () =>
            {
                await action();
                return NoContent();
            });
        }

        private async Task<ActionResult> ExecuteWithErrorHandling(Func<Task<ActionResult>> action)
        {
            try
            {
                return await action();
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
