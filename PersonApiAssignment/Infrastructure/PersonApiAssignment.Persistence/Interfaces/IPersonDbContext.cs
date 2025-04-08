using PersonApiAssignment.Domain.Entities;

namespace PersonApiAssignment.Persistence.Interfaces
{
    public interface IPersonDbContext
    {
        public List<Person> Persons { get; }
    }
}
