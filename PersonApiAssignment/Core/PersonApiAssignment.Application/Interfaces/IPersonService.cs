using PersonApiAssignment.Application.DTOs;
using PersonApiAssignment.Domain.Enums;

namespace PersonApiAssignment.Application.Interfaces
{
    public interface IPersonService
    {
        public PersonDTO CreatePerson(PersonToCreateDTO personDto);

        public PersonDTO UpdatePerson(PersonDTO personDto);

        public IEnumerable<PersonDTO> GetAllPersons(string? name, Gender? gender, string? birthPlace);

        public PersonDTO GetPersonById(int id); 

        public void DeletePerson(int id);   
    }
}
