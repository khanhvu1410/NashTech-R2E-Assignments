namespace EfCoreAssignmentDay2.Application.DTOs
{
    public class EmployeeSalaryDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime JoinedDate { get; set; }

        public decimal Salary { get; set; }
    }
}
