namespace EfCoreAssignmentDay1.Domain.Entities
{
    public class Salary
    {
        public int Id { get; set; }

        public decimal SalaryValue {  get; set; }

        public int EmployeeId { get; set; }

        public required Employee Employee { get; set; }
    }
}
