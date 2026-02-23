using Salary.Application.DTO;
using Salary.Application.Enum;
using Salary.Application.Mapper;
using Salary.Application.Services.Interfase;
using Salary.Application.Services.Parsers.Interface;
using Salary.Application.Services.Salery;
using Salary.Domain.Entity;
using Salary.Domain.Models;
using Salary.Infrastructure.Repository.Interface;

namespace Salary.Application.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISaleryRepository _repository;
        private readonly ISalaryCalculatorService _salary;
        private readonly ISalaryQueryRepository _queryRepository;
        private readonly ISalaryDatatypeFactory _salaryDatatype;
        private readonly SalaryInputMapper _mapper;

        public SalaryService(
            ISaleryRepository repository,
            ISalaryCalculatorService salary,
            ISalaryQueryRepository queryRepository,
            ISalaryDatatypeFactory salaryDatatype,
            SalaryInputMapper mapper)
        {
            _repository = repository;
            _salary = salary;
            _queryRepository = queryRepository;
            _salaryDatatype = salaryDatatype;
            _mapper = mapper;
        }

        public async Task<SalaryResult> AddSalaryUser(
            SalaryInputType dataType,
            SalaryRequest request)
        {
            var parser = _salaryDatatype.GetParser(dataType);

            // ✅ Parse → DTO
            SalaryRawDto rawDto = parser.Parse(request.Data);

            // ✅ DTO → Domain
            SalaryInput input = _mapper.Map(rawDto);

            var result = _salary.Calculate(input, request.OverTimeCalculator);

            var entity = new SalaryEntity
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                BasicSalary = input.BasicSalary,
                Allowance = input.Allowance,
                Transportation = input.Transportation,
                Overtime = result.Overtime,
                Tax = result.Tax,
                NetSalary = result.NetSalary,
                Date = input.Date
            };

            await _repository.AddAsync(entity);
            return result;
        }

        public async Task<bool> UpdateSalaryUser(
            SalaryInputType dataType,
            int id,
            SalaryRequest request)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return false;

            var parser = _salaryDatatype.GetParser(dataType);
            SalaryRawDto rawDto = parser.Parse(request.Data);
            SalaryInput input = _mapper.Map(rawDto);

            var result = _salary.Calculate(input, request.OverTimeCalculator);

            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            entity.BasicSalary = input.BasicSalary;
            entity.Allowance = input.Allowance;
            entity.Transportation = input.Transportation;
            entity.Date = input.Date;

            entity.Overtime = result.Overtime;
            entity.Tax = result.Tax;
            entity.NetSalary = result.NetSalary;

            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteSalaryUser(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return false;

            return await _repository.Delete(entity);
        }

        // ✅✅✅ Dapper 
        public async Task<SalaryReadDto?> Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id is invalid");

            return await _queryRepository.Get(id);
        }

        // ✅✅✅ Dapper 
        public async Task<IEnumerable<SalaryReadDto>> GetRange(
            string firstName,
            string lastName,
            string fromDate,
            string toDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName is required");

            return await _queryRepository.GetRange(
                firstName, lastName, fromDate, toDate);
        }
    }
}
