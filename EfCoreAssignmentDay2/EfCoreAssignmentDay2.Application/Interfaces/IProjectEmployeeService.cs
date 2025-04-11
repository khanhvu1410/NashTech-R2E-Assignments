using EfCoreAssignmentDay2.Application.DTOs;

namespace EfCoreAssignmentDay2.Application.Interfaces
{
    public interface IProjectEmployeeService
    {
        public Task<ProjectEmployeeDTO> AddProjectEmployeeAsync(ProjectEmployeeDTO projectEmployeeDto);

        public Task<IEnumerable<ProjectEmployeeDTO>> GetAllProjectEmployeesAsync();

        public Task<ProjectEmployeeDTO> GetProjectEmployeeByIdAsync(int projectId, int employeeId);

        public Task<ProjectEmployeeDTO> UpdateProjectEmployeeAsync(ProjectEmployeeDTO employeeDto);

        public Task DeleteProjectEmployeeAsync(int projectId, int employeeId);
    }
}
