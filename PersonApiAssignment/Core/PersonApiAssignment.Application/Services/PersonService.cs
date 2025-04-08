using PersonApiAssignment.Application.DTOs;
using PersonApiAssignment.Application.Interfaces;
using PersonApiAssignment.Application.Mappings;
using PersonApiAssignment.Domain.Enums;
using PersonApiAssignment.Domain.Interfaces;

namespace PersonApiAssignment.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonDTO CreatePerson(PersonToCreateDTO personDto)
        {
            var persons = _personRepository.GetAllPersons().ToList();

            var id = persons.Count == 0 ? 1 : persons.Max(i => i.Id) + 1;

            var person = _personRepository.CreatePerson(personDto.ToPerson(id));

            return person.ToPersonDTO();
        }

        public void DeletePerson(int id)
        {
            var person = _personRepository.GetPersonById(id);

            if (person == null)
            {
                throw new KeyNotFoundException($"No person with ID {id} found.");
            }

            _personRepository.DeletePerson(id);
        }

        public IEnumerable<PersonDTO> GetAllPersons(string? firstName = null, string? lastName = null, Gender? gender = null, string? birthPlace = null)
        {
            var persons = _personRepository.GetAllPersons().ToList();

            if (firstName != null)
            {
                persons = persons.Where(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (lastName != null)
            {
                persons = persons.Where(p => p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (gender != null)
            {
                persons = persons.Where(p => p.Gender == gender).ToList();
            }   

            if (birthPlace != null)
            {
                persons = persons.Where(p => p.BirthPlace.Equals(birthPlace, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (persons.Count == 0)
            {
                throw new KeyNotFoundException("No person found.");
            }

            return persons.Select(i => i.ToPersonDTO());
        }

        public PersonDTO GetPersonById(int id)
        {
            var person = _personRepository.GetPersonById(id);

            if (person == null)
            {
                throw new KeyNotFoundException($"No person with ID {id} found.");
            }

            return person.ToPersonDTO();
        }

        public PersonDTO UpdatePerson(PersonDTO personDto)
        {
            var existingPerson = _personRepository.GetPersonById(personDto.Id);

            if (existingPerson == null)
            {
                throw new KeyNotFoundException($"No person with ID {personDto.Id} found.");
            }

            var person = _personRepository.UpdatePerson(personDto.ToPerson());

            return person.ToPersonDTO();
        }
    }
}
