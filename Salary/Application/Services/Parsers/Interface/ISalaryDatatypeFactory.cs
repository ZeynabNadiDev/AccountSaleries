using Salary.Application.Enum;

namespace Salary.Application.Services.Parsers.Interface
{
    public interface ISalaryDatatypeFactory
    {
        ISalaryDataParser GetParser(SalaryInputType type);
    }
}
