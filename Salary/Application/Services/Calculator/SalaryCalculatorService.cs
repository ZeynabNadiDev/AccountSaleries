using OvertimePolicies;
using Salary.Application.DTO;
using Salary.Application.Services.Salery;
using Salary.Domain.Models;


namespace Salary.WebApi.Services;

public class SalaryCalculatorService : ISalaryCalculatorService
{
    private readonly OvertimeCalculator _overtimeCalculator;

    public SalaryCalculatorService()
    {
        _overtimeCalculator = new OvertimeCalculator();
    }

    public SalaryResult Calculate(SalaryInput input, string overTimeCalculator)
    {
        var basicSalary = input.BasicSalary;
        var allowance = input.Allowance;

        decimal overtime = overTimeCalculator switch
        {
            "CalculatorA" => _overtimeCalculator.CalcurlatorA(basicSalary, allowance),
            "CalculatorB" => _overtimeCalculator.CalcurlatorB(basicSalary, allowance),
            "CalculatorC" => _overtimeCalculator.CalcurlatorC(basicSalary, allowance),
            _ => throw new ArgumentException("Invalid OverTimeCalculator")
        };

        var tax = 0.1m * (input.BasicSalary + input.Allowance + overtime);

        var netSalary =
            input.BasicSalary +
            input.Allowance +
            input.Transportation +
            overtime -
            tax;

        return new SalaryResult
        {
            BasicSalary = input.BasicSalary,
            Allowance = input.Allowance,
            Transportation = input.Transportation,
            Overtime = overtime,
            Tax = tax,
            NetSalary = netSalary
        };
    }
}
