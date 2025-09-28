using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanApprovedController : ControllerBase
    {
        private readonly ILoanApprovedService _loanApprovedService;

        public LoanApprovedController(ILoanApprovedService loanApprovedService)
        {
            _loanApprovedService = loanApprovedService;
        }

        // ---------------------------
        // 1️⃣ Get all approved loans
        // ---------------------------
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loans = await _loanApprovedService.GetAll();
            return Ok(loans);
        }

        // ---------------------------
        // 2️⃣ Get approved loan by Id
        // ---------------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _loanApprovedService.GetById(id);
            if (loan == null) return NotFound("Approved loan not found.");
            return Ok(loan);
        }

        // ---------------------------
        // 3️⃣ Approve a loan
        // ---------------------------
        [HttpPost("approve/{loanApplicationId}")]
        public async Task<IActionResult> ApproveLoan(int loanApplicationId)
        {
            try
            {
                var approvedLoan = await _loanApprovedService.ApproveLoanAsync(loanApplicationId);
                return Ok(approvedLoan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ---------------------------
        // 4️⃣ Mark repayment as paid
        // ---------------------------
        [HttpPost("repayment/pay/{repaymentId}")]
        public async Task<IActionResult> MarkRepaymentPaid(int repaymentId)
        {
            try
            {
                await _loanApprovedService.MarkRepaymentAsPaidAsync(repaymentId);
                return Ok("Repayment marked as Paid");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ---------------------------
        // 5️⃣ Update overdue / NPA statuses
        // ---------------------------
        [HttpPost("repayment/update-overdues")]
        public async Task<IActionResult> UpdateOverdues()
        {
            await _loanApprovedService.UpdateOverduesAsync();
            return Ok("Overdues updated successfully");
        }

        // ---------------------------
        // 6️⃣ Get repayment schedule for an approved loan
        // ---------------------------
        [HttpGet("{approvedLoanId}/repayments")]
        public async Task<IActionResult> GetRepaymentSchedule(int approvedLoanId)
        {
            var loan = await _loanApprovedService.GetById(approvedLoanId);
            if (loan == null) return NotFound("Approved loan not found.");

            return Ok(loan.Repayments.OrderBy(r => r.InstallmentNumber));
        }
    }
}
