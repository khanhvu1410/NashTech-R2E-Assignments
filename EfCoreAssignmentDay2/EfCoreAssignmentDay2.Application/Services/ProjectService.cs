using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using EfCoreAssignmentDay2.Application.Mappings;
using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;

namespace EfCoreAssignmentDay2.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IBaseRepository<Project> _projectRepository;

        public ProjectService(IBaseRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectToAddDTO projectDto)
        {
            Project project = projectDto.ToProject();
            await _projectRepository.AddAsync(project);
            return project.ToProjectDTO();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} was not found.");
            }

            await _projectRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(p => p.ToProjectDTO());
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
            {
                throw new KeyNotFoundException($"Project with ID {id} was not found.");
            }

            return project.ToProjectDTO();
        }

        public async Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDto)
        {
            var project = await _projectRepository.GetByIdAsync(projectDto.Id) ?? throw new KeyNotFoundException($"Project with ID {projectDto.Id} was not found.");
            await _projectRepository.UpdateAsync(project);
            return projectDto;
        }
    }
}
