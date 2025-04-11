using EfCoreAssignmentDay2.Application.DTOs;
using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.Mappings
{
    public static class ProjectMapping
    {
        public static ProjectDTO ToProjectDTO(this Project project)
        {
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name
            };
        }

        public static Project ToProject(this ProjectToAddDTO projectDto)
        {
            return new Project
            {
                Name = projectDto.Name
            };
        }

        public static Project ToProject(this ProjectDTO projectDto)
        {
            return new Project
            {
                Id = projectDto.Id,
                Name = projectDto.Name
            };
        }
    }
}
