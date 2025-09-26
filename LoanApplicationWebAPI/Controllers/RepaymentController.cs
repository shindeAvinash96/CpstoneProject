using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepaymentsController : ControllerBase
    {
        private readonly IRepaymentService _service;

        public RepaymentsController(IRepaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var repayment = await _service.GetById(id);
            if (repayment == null) return NotFound();
            return Ok(repayment);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Repayment repayment)
        {
            var created = await _service.Add(repayment);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Repayment repayment)
        {
            if (id != repayment.Id) return BadRequest();
            var updated = await _service.Update(repayment);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
