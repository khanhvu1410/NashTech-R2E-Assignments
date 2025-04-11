using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Mappings;
using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;

namespace EfCoreAssignmentDay2.Application.Services
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        private readonly IBaseRepository<Project> _projectRepository;

        private readonly IEmployeeRepository _employeeRepository;

        public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository, IEmployeeRepository employeeRepository, IBaseRepository<Project> projectRepository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ProjectEmployeeDTO> AddProjectEmployeeAsync(ProjectEmployeeDTO projectEmployeeDto)
        {
            var project = await _projectRepository.GetByIdAsync(projectEmployeeDto.EmployeeId);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectEmployeeDto.EmployeeId} was not found.");
            }

            var employee = await _employeeRepository.GetByIdAsync(projectEmployeeDto.EmployeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {projectEmployeeDto.EmployeeId} was not found.");
            }

            var exisitingProjectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectEmployeeDto.ProjectId, projectEmployeeDto.EmployeeId);

            if (exisitingProjectEmployee != null)
            {
                throw new InvalidOperationException($"Employee {projectEmployeeDto.ProjectId} is already assigned to Project {projectEmployeeDto.EmployeeId}.");
            }

            ProjectEmployee projectEmployee = projectEmployeeDto.ToProjectEmployee();
            await _projectEmployeeRepository.AddAsync(projectEmployee);
            return projectEmployee.ToProjectEmployeeDTO();
        }

        public async Task DeleteProjectEmployeeAsync(int projectId, int employeeId)
        {
            var projectEmployees = await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);

            if (projectEmployees == null)
            {
                throw new KeyNotFoundException($"ProjectEmployee with ProjectId = {projectId} and EmployeeId = {employeeId} was not found.");
            }

            await _projectEmployeeRepository.DeleteAsync(projectId, employeeId);
        }

        public async Task<IEnumerable<ProjectEmployeeDTO>> GetAllProjectEmployeesAsync()
        {
            var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
            return projectEmployees.Select(pe => pe.ToProjectEmployeeDTO());
        }

        public async Task<ProjectEmployeeDTO> GetProjectEmployeeByIdAsync(int projectId, int employeeId)
        {
            var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);

            if (projectEmployee == null)
            {
                throw new KeyNotFoundException($"ProjectEmployee with ProjectId = {projectId} and EmployeeId = {employeeId} was not found.");
            }

            return projectEmployee.ToProjectEmployeeDTO();
        }

        public async Task<ProjectEmployeeDTO> UpdateProjectEmployeeAsync(ProjectEmployeeDTO projectEmployeeDto)
        {
            var project = await _projectRepository.GetByIdAsync(projectEmployeeDto.EmployeeId);
            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {projectEmployeeDto.EmployeeId} was not found.");
            }

            var employee = await _employeeRepository.GetByIdAsync(projectEmployeeDto.EmployeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {projectEmployeeDto.EmployeeId} was not found.");
            }

            var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectEmployeeDto.ProjectId, projectEmployeeDto.EmployeeId) ?? throw new KeyNotFoundException($"ProjectEmployee with ProjectId = {projectEmployeeDto.ProjectId} and EmployeeId = {projectEmployeeDto.EmployeeId} was not found.");

            await _projectEmployeeRepository.UpdateAsync(projectEmployee);
            return projectEmployeeDto;
        }
    }
}
