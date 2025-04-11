using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.Mappings
{
    public static class DepartmentMapping
    {
        public static DepartmentDTO ToDepartmentDTO(this Department department)
        {
            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        public static Department ToDepartment(this DepartmentToAddDTO departmentDTO)
        {
            return new Department
            {
                Name = departmentDTO.Name,
            };
        }

        public static Department ToDepartment(this DepartmentDTO departmentDTO)
        {
            return new Department
            {
                Id = departmentDTO.Id,
                Name = departmentDTO.Name,
            };
        }
    }
}
