namespace EfCoreAssignmentDay2.Domain.Entities
{
    public class Salaries
    {
        public int Id { get; set; }

        public decimal Salary {  get; set; }

        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
