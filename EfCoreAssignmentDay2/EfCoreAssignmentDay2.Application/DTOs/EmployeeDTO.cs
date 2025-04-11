namespace EfCoreAssignmentDay2.Application.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public int DepartmentId { get; set; }
    }
}
