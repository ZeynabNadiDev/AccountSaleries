namespace Salary.Application.DTO
{
    public class SalaryReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal OverTime { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
        public string Date { get; set; } = null!;
    }
}
