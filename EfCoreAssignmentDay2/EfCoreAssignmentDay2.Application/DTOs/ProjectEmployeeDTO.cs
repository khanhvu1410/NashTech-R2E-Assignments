using EfCoreAssignmentDay2.Domain.Entities;

namespace EfCoreAssignmentDay2.Application.DTOs
{
    public class ProjectEmployeeDTO
    {
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public bool Enable { get; set; }
    }
}
