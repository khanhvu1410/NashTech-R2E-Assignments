using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.Mappings
{
    internal static class EmployeeMapping
    {
        public static EmployeeDTO ToEmployeeDTO(this Employee employee)
        {
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                JoinedDate = employee.JoinedDate,
                DepartmentId = employee.DepartmentId
            };
        }

        public static Employee ToEmployee(this EmployeeToAddDTO employeeDto)
        {
            return new Employee
            {
                Name = employeeDto.Name,
                JoinedDate = employeeDto.JoinedDate,
                DepartmentId = employeeDto.DepartmentId
            };
        }

        public static Employee ToEmployee(this EmployeeDTO employeeDto)
        {
            return new Employee
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                JoinedDate = employeeDto.JoinedDate,
                DepartmentId = employeeDto.DepartmentId
            };
        }
    }
}
