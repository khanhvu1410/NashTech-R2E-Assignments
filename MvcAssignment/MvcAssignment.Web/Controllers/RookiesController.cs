using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcAssignment.Business.Interfaces;
using MvcAssignment.Shared.DTOs;
using MvcAssignment.Shared.Enums;

namespace MvcAssignment.Web.Controllers
{
    public class RookiesController : CustomBaseController
    {
        private readonly IPersonService _personService;

        public RookiesController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("NashTech/[controller]/[action]")]
        public IActionResult Index()
        {
            var rookies = _personService.GetAllMembers();
            return View(rookies);
        }

        public IActionResult GetMaleRookies()
        {
            var rookies = _personService.GetMaleMembers();
            return View("Index", rookies);
        }

        public IActionResult GetOldestRookie()
        {
            return SafeExecute(() =>
            {
                var rookie = _personService.GetOldestMember();
                return rookie;
            }, nameof(GetOldestRookie));
        }

        public IActionResult GetFullnames()
        {
            return SafeExecute(() =>
            {
                var fullnames = _personService.GetFullnames();
                return fullnames;
            }, nameof(GetFullnames));
        }

        public IActionResult RedirectBasedOnOption(Option option, int year)
        {
            var actionName = option switch
            {
                Option.Equal => nameof(GetRookiesByBirthYear),
                Option.Greater => nameof(GetRookiesByBirthYearGreater),
                Option.Less => nameof(GetRookiesByBirthYearLess),
                _ => nameof(GetRookiesByBirthYear)
            };

            return RedirectToAction(actionName, new { year });
        }

        public IActionResult GetRookiesByBirthYear(int year)
        {
            var rookies = _personService.GetMembersByBirthYear(Option.Equal, year);
            return View("Index", rookies);
        }

        public IActionResult GetRookiesByBirthYearGreater(int year)
        {
            var rookies = _personService.GetMembersByBirthYear(Option.Greater, year);
            return View("Index", rookies);
        }

        public IActionResult GetRookiesByBirthYearLess(int year)
        {
            var rookies = _personService.GetMembersByBirthYear(Option.Less, year);
            return View("Index", rookies);
        }

        public IActionResult ExportExcel()
        {
            return SafeFileExecute(() =>
            {
                var result = _personService.WriteMembersToExcel();
                return result;
            }, "Rookies.xlsx");
        }

        public IActionResult CreateNewRookie()
        {
            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewRookie(PersonToCreateDTO person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
                return View();
            }

            _personService.CreateNewMember(person);
            return RedirectToAction("Index");    
        }

        public IActionResult EditRookie(int id)
        {
            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
            var rookie = _personService.GetMemberById(id);
            return View(rookie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRookie(PersonDTO person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
                    return View(person);
                }

                _personService.EditMember(person);              
                return RedirectToAction("Index");
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

        public IActionResult GetRookieDetails(int id)
        {
            return SafeExecute(() =>
            {
                var rookie = _personService.GetMemberById(id);
                return rookie;
            }, nameof(GetRookieDetails));
        }

        public IActionResult DeleteRookie(int id, string name)
        {
            return SafeExecute(() =>
            {
                _personService.DeleteMember(id);
                var message = $"Person {name} was removed from the list successfully!";
                return message;
            }, "RookiesSuccess");
        }
    }
}