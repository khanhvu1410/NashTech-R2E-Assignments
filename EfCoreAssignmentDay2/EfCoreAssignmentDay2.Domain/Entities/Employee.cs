namespace EfCoreAssignmentDay2.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public int DepartmentId { get; set; }

        public Salaries? Salary { get; set; }

        public Department? Department { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
