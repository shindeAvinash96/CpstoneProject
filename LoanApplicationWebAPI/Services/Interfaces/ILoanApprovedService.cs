using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Services.Interfaces
{
    public interface ILoanApprovedService
    {

        Task<IEnumerable<LoanApproved>> GetAll();
        Task<LoanApproved> GetById(int id);
        Task<LoanApproved> Add(LoanApproved approved);
        Task<LoanApproved> Update(LoanApproved approved);
        Task Delete(int id);

        Task<LoanApproved> ApproveLoanAsync(int loanApplicationId);

        Task MarkRepaymentAsPaidAsync(int repaymentId);
        Task UpdateOverduesAsync();
    }
}
