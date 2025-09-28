using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class LoanApprovedRepo : ILoanApprovedRepo
    {
        private readonly AppDbContext _context;

        public LoanApprovedRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanApproved>> GetAll()
        {
            return await _context.LoanApproved.ToListAsync();
        }

        public async Task<LoanApproved> GetById(int id)
        {
            return await _context.LoanApproved.FindAsync(id);
        }

        public async Task<LoanApproved> Add(LoanApproved approved)
        {
            await _context.LoanApproved.AddAsync(approved);
            await _context.SaveChangesAsync();
            return approved;
        }

        public async Task<LoanApproved> Update(LoanApproved approved)
        {
            _context.LoanApproved.Update(approved);
            await _context.SaveChangesAsync();
            return approved;
        }

        public async Task Delete(int id)
        {
            var approved = await GetById(id);
            if (approved != null)
            {
                _context.LoanApproved.Remove(approved);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkRepaymentAsPaidAsync(int repaymentId)
        {
            var repayment = await _context.Repayments.FindAsync(repaymentId);
            if (repayment == null) throw new Exception("Repayment not found.");

            repayment.IsPaid = true;
            repayment.PaidDate = DateTime.UtcNow;
            repayment.Status = RepaymentStatus.Paid;

            await _context.SaveChangesAsync();
        }

        // ------------------ New: Update overdue / NPA ------------------
        public async Task UpdateOverduesAsync()
        {
            var today = DateTime.UtcNow;

            var overdueRepayments = await _context.Repayments
                .Where(r => !r.IsPaid && r.DueDate < today)
                .ToListAsync();

            foreach (var repayment in overdueRepayments)
            {
                var daysOverdue = (today - repayment.DueDate).Days;
                repayment.Status = daysOverdue > 90 ? RepaymentStatus.NPA : RepaymentStatus.Overdue;
            }

            await _context.SaveChangesAsync();
        }
        public async Task<LoanApproved> ApproveLoanAsync(int loanApplicationId)
        {
            var loanApplication = await _context.LoanApplications
                .Include(l => l.LoanScheme)
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(l => l.LoanApplicationId == loanApplicationId);

            //var loanApplication = this.GetById(loanApplicationId);

            if (loanApplication == null)
                throw new Exception("Loan Application not found.");

            if (loanApplication.Status != ApplicationStatus.Pending)
                throw new Exception("Loan Application already processed.");

            loanApplication.Status = ApplicationStatus.Approved;

            var scheme = loanApplication.LoanScheme;

            // Total amount = requested amount + interest
            var totalAmount = loanApplication.LoanAmount +
                              (loanApplication.LoanAmount * (decimal)scheme.InterestRate * scheme.TenureInMonths / 12);

            int numberOfPayments = scheme.TenureInMonths;
            decimal installmentAmount = totalAmount / numberOfPayments;

            var approvedLoan = new LoanApproved
            {
                LoanApplicationId = loanApplication.LoanApplicationId,
                TotalAmount = totalAmount,
                NoOfPayments = numberOfPayments,
                Installment = installmentAmount,
                StartDate = DateTime.UtcNow
            };

            for (int i = 1; i <= numberOfPayments; i++)
            {
                approvedLoan.Repayments.Add(new Repayment
                {
                    InstallmentNumber = i,
                    Amount = installmentAmount,
                    DueDate = approvedLoan.StartDate.AddMonths(i),
                    Status = RepaymentStatus.Pending
                });
            }

            _context.LoanApproved.Add(approvedLoan);
            await _context.SaveChangesAsync();

            return approvedLoan;
        }

    }
}
