using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Domain.Interfaces
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        Task<ProjectEmployee?> GetByIdsAsync(int projectId, int employeeId);

        Task DeleteAsync(int projectId, int employeeId);
    }
}
