using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Domain.Interfaces
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        public Task<ProjectEmployee?> GetByIdAsync(int projectId, int employeeId);

        public Task DeleteAsync(int projectId, int employeeId);
    }
}
