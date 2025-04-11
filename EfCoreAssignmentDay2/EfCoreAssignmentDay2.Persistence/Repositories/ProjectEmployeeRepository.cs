using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay2.Persistence.Repositories
{
    public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        public ProjectEmployeeRepository(CompanyDbContext context) : base(context)
        {
        }

        public async Task<ProjectEmployee?> GetByIdAsync(int projectId, int employeeId)
        {
            var projectEmployees = await _context.ProjectEmployees
                .Where(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId).FirstOrDefaultAsync();

            return projectEmployees;
        }

        public async Task DeleteAsync(int projectId, int employeeId)
        {
            var projectEmployee = await GetByIdAsync(projectId, employeeId);
            if (projectEmployee != null)
            {
                _context.ProjectEmployees.Remove(projectEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
