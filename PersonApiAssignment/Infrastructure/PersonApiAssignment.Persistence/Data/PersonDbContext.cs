using PersonApiAssignment.Domain.Entities;
using PersonApiAssignment.Domain.Enums;
using PersonApiAssignment.Persistence.Interfaces;

namespace PersonApiAssignment.Persistence.Data
{
    public class PersonDbContext : IPersonDbContext
    {
        private List<Person> _persons = [
            new Person
            {
                Id = 1,
                FirstName = "Khánh",
                LastName = "Vũ",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("2003-10-14"),
                BirthPlace = "Hà Nội",
                CreatedAt = DateTime.Parse("2025-04-01")
            },
            new Person
            {
                Id = 2,
                FirstName = "Chiến Văn",
                LastName = "Thái",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("2003-07-29"),
                BirthPlace = "Hà Nội",
                CreatedAt = DateTime.Parse("2025-04-01")
            },
            new Person
            {
                Id = 3,
                FirstName = "Giang Hồng",
                LastName = "Nguyễn",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("2003-05-22"),
                BirthPlace = "Bắc Ninh",
                CreatedAt = DateTime.Parse("2025-04-01")
            },
            new Person
            {
                Id = 4,
                FirstName = "Lâm Đức",
                LastName = "Trần",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Parse("1993-03-22"),
                BirthPlace = "Nam Định",
                CreatedAt = DateTime.Parse("2025-04-01")
            },
            new Person
            {
                Id = 5,
                FirstName = "Linh Thùy",
                LastName = "Trần",
                Gender = Gender.Female,
                DateOfBirth = DateTime.Parse("2000-01-25"),
                BirthPlace = "Thái Bình",
                CreatedAt = DateTime.Parse("2025-04-01")
            }
        ];

        public List<Person> Persons { get => _persons; }
    }
}
