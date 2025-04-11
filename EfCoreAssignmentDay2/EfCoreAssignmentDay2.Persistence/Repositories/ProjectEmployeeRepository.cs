using EfCoreAssignmentDay2.Domain.Entities;
using EfCoreAssignmentDay2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EfCoreAssignmentDay2.Persistence.Repositories
{
    public class ProjectEmployeeRepository : IProjectEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public ProjectEmployeeRepository(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<ProjectEmployee?> GetByIdsAsync(int projectId, int employeeId)
        {
            var projectEmployees = await _context.ProjectEmployees
                .Where(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId).FirstOrDefaultAsync();

            return projectEmployees;
        }

        public async Task DeleteAsync(int projectId, int employeeId)
        {
            var projectEmployee = await GetByIdsAsync(projectId, employeeId);
            if (projectEmployee != null)
            {
                _context.ProjectEmployees.Remove(projectEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAsync(ProjectEmployee projectEmployee)
        {
            await _context.ProjectEmployees.AddAsync(projectEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProjectEmployee projectEmployee)
        {
            _context.ProjectEmployees.Update(projectEmployee);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<ProjectEmployee>> GetAllAsync()
        {
            return await _context.ProjectEmployees.ToListAsync();
        }

        public Task<ProjectEmployee?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
