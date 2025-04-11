namespace EfCoreAssignmentDay2.Domain.Entities
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public bool Enable { get; set; }

        public Project? Project { get; set; }

        public Employee? Employee { get; set; }  
    }
}
