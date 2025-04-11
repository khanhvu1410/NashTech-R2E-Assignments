using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.Mappings
{
    public static class SalariesMapping
    {
        public static SalariesDTO ToSalariesDTO(this Salaries salaries)
        {
            return new SalariesDTO
            {
                Id = salaries.Id,
                Salary = salaries.Salary,
                EmployeeId = salaries.EmployeeId
            };
        }

        public static Salaries ToSalaries(this SalariesToAddDTO salariesDto)
        {
            return new Salaries
            {
                Salary = salariesDto.Salary,
                EmployeeId = salariesDto.EmployeeId
            };
        }

        public static Salaries ToSalaries(this SalariesDTO salariesDto)
        {
            return new Salaries
            {
                Id = salariesDto.Id,
                Salary = salariesDto.Salary,
                EmployeeId = salariesDto.EmployeeId
            };
        }
    }
}
