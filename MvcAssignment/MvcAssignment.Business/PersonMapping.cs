using MvcAssignment.Data.Models;
using MvcAssignment.Shared.DTOs;

namespace MvcAssignment.Business
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
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
                IsGraduated = person.IsGraduated,
            };
        }

        public static Person ToPerson(this PersonDTO personDto)
        {
            return new Person
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Gender = personDto.Gender,
                DateOfBirth = personDto.DateOfBirth,
                PhoneNumber = personDto.PhoneNumber,
                BirthPlace = personDto.BirthPlace,
                IsGraduated = personDto.IsGraduated,
                UpdatedDate = DateTime.UtcNow,
            };
        }

        public static Person ToPerson(this PersonToCreateDTO personDto, int id)
        {
            return new Person
            {
                Id = id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                Gender = personDto.Gender,
                DateOfBirth = personDto.DateOfBirth,
                PhoneNumber = personDto.PhoneNumber,
                BirthPlace = personDto.BirthPlace,
                IsGraduated = personDto.IsGraduated,
                UpdatedDate = DateTime.UtcNow,
            };
        }
    }
}
