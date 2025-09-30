using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationWebAPI.Services
{
    public class RepaymentService : IRepaymentService
    {
        private readonly IRepaymentRepo _repaymentRepo;
        private readonly ILoanApprovedRepo _loanApprovedRepo;

        public RepaymentService(IRepaymentRepo repaymentRepo, ILoanApprovedRepo loanApprovedRepo)
        {
            _repaymentRepo = repaymentRepo;
            _loanApprovedRepo = loanApprovedRepo;
        }

        // Basic CRUD
        public async Task<IEnumerable<Repayment>> GetAll()
        {
            return await _repaymentRepo.GetAll();
        }

        public async Task<Repayment> GetById(int id)
        {
            return await _repaymentRepo.GetById(id);
        }

        public async Task<Repayment> Add(Repayment repayment)
        {
            return await _repaymentRepo.Add(repayment);
        }

        public async Task<Repayment> Update(Repayment repayment)
        {
            return await _repaymentRepo.Update(repayment);
        }

        public async Task Delete(int id)
        {
            await _repaymentRepo.Delete(id);
        }

        // ✅ Mark repayment as paid
        public async Task MarkRepaymentAsPaidAsync(int repaymentId)
        {
            var repayment = await _repaymentRepo.GetById(repaymentId);
            if (repayment == null)
                throw new KeyNotFoundException($"Repayment with ID {repaymentId} not found.");

            repayment.IsPaid = true;
            repayment.PaidDate = DateTime.UtcNow;

            await _repaymentRepo.Update(repayment);
        }

        // ✅ Update overdue repayments and notify Loan Officer
        public async Task UpdateOverduesAndNotifyAsync(CancellationToken ct)
        {
            var allRepayments = await _repaymentRepo.GetAll();

            var overdueRepayments = allRepayments
                .Where(r => !r.IsPaid && r.DueDate < DateTime.UtcNow)
                .ToList();

            foreach (var repayment in overdueRepayments)
            {
                // Optional: you could set a flag or send notification here
                // e.g., repayment.IsOverdue = true; (if you add that property)
                // Notify loan officer if needed (e.g., via email or in-app notification)
            }

            // Save changes if you modified any properties
            foreach (var repayment in overdueRepayments)
            {
                await _repaymentRepo.Update(repayment);
            }
        }
    }
}
