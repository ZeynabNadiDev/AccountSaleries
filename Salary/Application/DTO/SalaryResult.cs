namespace Salary.Application.DTO
{
    public class SalaryResult
    {
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal Overtime { get; set; }
        public decimal Tax { get; set; }
        public decimal NetSalary { get; set; }
    }
}
