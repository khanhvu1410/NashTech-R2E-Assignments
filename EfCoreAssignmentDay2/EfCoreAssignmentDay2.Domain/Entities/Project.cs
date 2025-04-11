namespace EfCoreAssignmentDay2.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }
    }
}
