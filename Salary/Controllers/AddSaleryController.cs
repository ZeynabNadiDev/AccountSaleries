using Microsoft.AspNetCore.Mvc;
using Salary.Application.DTO;
using Salary.Application.Enum;
using Salary.Application.Services.Interfase;

namespace Salary.Controllers
{
    [Route("api/{dataType}/salary")]
    [ApiController]
    public class AddSaleryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public AddSaleryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(
                [FromRoute] string dataType,
                [FromBody] SalaryRequest request)
        {
            if (!Enum.TryParse<SalaryInputType>(
                  dataType,
                   true,
                   out var inputType))
            {
                return BadRequest("Invalid data type");
            }
            var result = await _salaryService.AddSalaryUser(inputType, request);

            return Ok(result);
        }
    }
}
