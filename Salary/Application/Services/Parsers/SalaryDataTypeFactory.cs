using Salary.Application.Enum;
using Salary.Application.Services.Parsers.Interface;

namespace Salary.Application.Services.Parsers
{
    public class SalaryDataTypeFactory : ISalaryDatatypeFactory
    {
        private readonly CustomSalaryDataParser _customParser;
        private readonly JsonSalaryDataParser _jsonParser;
        private readonly XmlSalaryDataParser _xmlParser;

        public SalaryDataTypeFactory(
            CustomSalaryDataParser customParser,
            JsonSalaryDataParser jsonParser,
            XmlSalaryDataParser xmlParser)
        {
            _customParser = customParser;
            _jsonParser = jsonParser;
            _xmlParser = xmlParser;
        }
        public ISalaryDataParser GetParser(SalaryInputType type)
        {
            return type switch
            {
                SalaryInputType.Custom => _customParser,
                SalaryInputType.Json => _jsonParser,
                SalaryInputType.Xml => _xmlParser,
                _ => throw new ArgumentException("Invalid salary input type")
            };
        }
    }
}
