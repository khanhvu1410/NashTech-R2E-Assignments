using Microsoft.AspNetCore.Mvc;

namespace MvcAssignment.Web.Controllers
{
    public class CustomBaseController : Controller
    {
        protected IActionResult SafeExecute<T>(Func<T> action, string actionName)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var result = action();
                return View(actionName, result);
            });
        }

        protected IActionResult SafeFileExecute(Func<MemoryStream> action, string fileName)
        {
            return ExecuteWithErrorHandling(() =>
            {
                var result = action();
                return File(result, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            });
        }

        private IActionResult ExecuteWithErrorHandling(Func<IActionResult> action)
        {
            try
            {
                return action();
            }
            catch (KeyNotFoundException ex)
            {
                return View("RookiesNotFound", ex.Message);
            }
            catch (Exception ex)
            {
                return View("RookiesError", ex.Message);
            }
        }
    }
}
