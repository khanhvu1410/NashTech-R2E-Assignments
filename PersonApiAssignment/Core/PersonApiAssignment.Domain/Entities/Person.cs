using PersonApiAssignment.Domain.Enums;

namespace PersonApiAssignment.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }   

        public required string LastName {  get; set; }

        public DateTime DateOfBirth { get; set; }   

        public Gender Gender { get; set; }

        public required string BirthPlace { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
