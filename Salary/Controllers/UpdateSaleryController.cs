using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salary.Application.DTO;
using Salary.Application.Enum;
using Salary.Application.Services.Interfase;

namespace Salary.Controllers
{
    [Route("api/{dataType}/salary")]
    [ApiController]
    public class UpdateSaleryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public UpdateSaleryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] string dataType,
            [FromRoute] int id,
            [FromBody] SalaryRequest request)

        {
            if (!Enum.TryParse<SalaryInputType>(
                   dataType,
                   true,
                   out var inputType))
            {
                return BadRequest("Invalid data type");
            }

            var result = await _salaryService.UpdateSalaryUser(inputType,id, request);
            return result
                ? Ok("Updated successfully")
                : NotFound("Record not found");
        }
    }
}
