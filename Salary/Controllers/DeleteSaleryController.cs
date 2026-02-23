using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salary.Application.Services.Interfase;

namespace Salary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteSaleryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public DeleteSaleryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _salaryService.DeleteSalaryUser(id);

            return result
                ? Ok("Deleted successfully")
                : NotFound("Record not found");
        }
    }
}
