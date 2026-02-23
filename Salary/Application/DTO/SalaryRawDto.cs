namespace Salary.Application.DTO
{
    public class SalaryRawDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public string? Date { get; set; }
    }
}
