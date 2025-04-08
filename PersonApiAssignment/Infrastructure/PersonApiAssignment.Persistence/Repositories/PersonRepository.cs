using PersonApiAssignment.Domain.Entities;
using PersonApiAssignment.Domain.Interfaces;
using PersonApiAssignment.Persistence.Interfaces;

namespace PersonApiAssignment.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPersonDbContext _context;

        public PersonRepository(IPersonDbContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            return person;
        }

        public void DeletePerson(int id)
        {
            _context.Persons.RemoveAll(p => p.Id == id);    
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons;
        }

        public Person? GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id == id);
        }

        public Person UpdatePerson(Person person)
        {
            var exisitingPerson = _context.Persons.FirstOrDefault(p => p.Id == person.Id);

            if (exisitingPerson != null)
            {
                exisitingPerson.FirstName = person.FirstName;
                exisitingPerson.LastName = person.LastName;
                exisitingPerson.Gender = person.Gender;
                exisitingPerson.DateOfBirth = person.DateOfBirth;
                exisitingPerson.BirthPlace = person.BirthPlace;
                exisitingPerson.UpdatedAt = DateTime.Now;
            }

            return person;
        }
    }
}
