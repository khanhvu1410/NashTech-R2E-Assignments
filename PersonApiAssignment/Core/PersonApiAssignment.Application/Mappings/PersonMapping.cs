using PersonApiAssignment.Application.DTOs;
using PersonApiAssignment.Domain.Entities;

namespace PersonApiAssignment.Application.Mappings
{
    public static class PersonMapping
    {
        public static PersonDTO ToPersonDTO(this Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                BirthPlace = person.BirthPlace,
            };
        }

        public static Person ToPerson(this PersonDTO personDto)
        {
            return new Person
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName ?? string.Empty,
                LastName = personDto.LastName ?? string.Empty,
                DateOfBirth = personDto.DateOfBirth,
                Gender = personDto.Gender,
                BirthPlace = personDto.BirthPlace ?? string.Empty,
                UpdatedAt = DateTime.Now
            };
        }

        public static Person ToPerson(this PersonToCreateDTO personDto, int id)
        {
            return new Person
            {
                Id = id,
                FirstName = personDto.FirstName ?? string.Empty,
                LastName = personDto.LastName ?? string.Empty,
                DateOfBirth = personDto.DateOfBirth,
                Gender = personDto.Gender,
                BirthPlace = personDto.BirthPlace ?? string.Empty,
                CreatedAt = DateTime.Now
            };
        }
    }
}
