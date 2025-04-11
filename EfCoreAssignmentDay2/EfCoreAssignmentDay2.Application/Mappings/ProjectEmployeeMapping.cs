using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.Mappings
{
    public static class ProjectEmployeeMapping
    {
        public static ProjectEmployeeDTO ToProjectEmployeeDTO(this ProjectEmployee projectEmployee)
        {
            return new ProjectEmployeeDTO
            {
                ProjectId = projectEmployee.ProjectId,
                EmployeeId = projectEmployee.EmployeeId,
                Enable = projectEmployee.Enable,
            };
        }

        public static ProjectEmployee ToProjectEmployee(this ProjectEmployeeDTO projectEmployeeDto)
        {
            return new ProjectEmployee
            {
                ProjectId = projectEmployeeDto.ProjectId,
                EmployeeId = projectEmployeeDto.EmployeeId,
                Enable = projectEmployeeDto.Enable,
            };
        }
    }
}
