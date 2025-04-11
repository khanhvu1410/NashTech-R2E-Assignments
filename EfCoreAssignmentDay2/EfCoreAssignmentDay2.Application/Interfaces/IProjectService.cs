using EfCoreAssignmentDay2.Application.DTOs;

namespace EfCoreAssignmentDay2.Application.Interfaces
{
    public interface IProjectService
    {
        public Task<ProjectDTO> AddProjectAsync(ProjectToAddDTO projectDto);

        public Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();

        public Task<ProjectDTO> GetProjectByIdAsync(int id);

        public Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDto);

        public Task DeleteProjectAsync(int id);
    }
}
