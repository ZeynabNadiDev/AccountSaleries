namespace Salary.Domain.Entity
{
    public class SalaryEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }

        public decimal Overtime { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }

        public DateTime Date { get; set; }
    }
}
