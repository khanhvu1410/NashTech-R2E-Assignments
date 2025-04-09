namespace EfCoreAssignmentDay1.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public required Salary Salary { get; set; }

        public int DepartmentId { get; set; }

        public required Department Department { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
