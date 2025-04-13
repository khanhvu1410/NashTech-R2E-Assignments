namespace EfCoreAssignmentDay2.Application.DTOs
{
    public class EmployeeProjectDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public IEnumerable<string>? ProjectNames { get; set; }
    }
}
