using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreAssignmentDay2.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : CustomBaseController
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> CreateProject(ProjectToAddDTO projectDto)
        {
            var projects = await _projectService.AddProjectAsync(projectDto);

            return CreatedAtAction(nameof(GetProjectById), new { id = projects.Id }, projects);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(int id)
        {
            return await SafeExecute(async () =>
            {
                var project = await _projectService.GetProjectByIdAsync(id);
                return project;
            });
        }

        [HttpPut]
        public async Task<ActionResult<ProjectDTO>> UpdateProject(ProjectDTO projectDto)
        {
            return await SafeExecute(async () =>
            {
                var project = await _projectService.UpdateProjectAsync(projectDto);
                return project;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            return await SafeDeleteExecute(async () =>
            {
                await _projectService.DeleteProjectAsync(id);
            });
        }
    }
}
