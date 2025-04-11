using EfCoreAssignmentDay2.Application.DTOs;

namespace EfCoreAssignmentDay2.Application.Interfaces
{
    public interface IDepartmentService
    {
        public Task<DepartmentDTO> AddDepartmentAsync(DepartmentToAddDTO departmentDto);

        public Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

        public Task<DepartmentDTO> GetDepartmentByIdAsync(int id);

        public Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO departmentDto);

        public Task DeleteDepartmentAsync(int id);
    }
}
