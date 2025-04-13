namespace EfCoreAssignmentDay2.Application.DTOs
{
    public class EmployeeDepartmentDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public string? DepartmentName { get; set; } 
    }
}
