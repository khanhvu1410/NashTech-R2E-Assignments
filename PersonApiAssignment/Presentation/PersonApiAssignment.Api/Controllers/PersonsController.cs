using Microsoft.AspNetCore.Mvc;
using PersonApiAssignment.Application.DTOs;
using PersonApiAssignment.Application.Interfaces;
using PersonApiAssignment.Domain.Enums;

namespace PersonApiAssignment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : CustomBaseController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PersonDTO>> GetAllPersons(string? firstName = null, string? lastName = null, Gender? gender = null, string? birthPlace = null)
        {
            return SafeExecute(() => _personService.GetAllPersons(firstName, lastName, gender, birthPlace));
        }

        [HttpGet("{id}")]
        public ActionResult<PersonDTO> GetPersonById(int id)
        {
            return SafeExecute(() => _personService.GetPersonById(id));
        }

        [HttpPost]
        public ActionResult<PersonDTO> CreatePerson(PersonToCreateDTO personDto)
        {
            return SafeExecute(() => _personService.CreatePerson(personDto));
        }

        [HttpPut]
        public ActionResult<PersonDTO> UpdatePerson(PersonDTO personDto)
        {
            return SafeExecute(() => _personService.UpdatePerson(personDto));
        }

        [HttpDelete]
        public IActionResult DeletePerson(int id)
        {
            return SafeDeleteExecute(() => _personService.DeletePerson(id));
        }
    }
}
