using PersonApiAssignment.Domain.Entities;

namespace PersonApiAssignment.Domain.Interfaces
{
    public interface IPersonRepository
    {
        public Person CreatePerson(Person person);
        
        public Person UpdatePerson(Person person);

        public void DeletePerson(int id);
        
        public IEnumerable<Person> GetAllPersons();

        public Person? GetPersonById(int id);
    }
}
