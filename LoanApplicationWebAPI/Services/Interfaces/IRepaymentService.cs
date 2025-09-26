using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Services.Interfaces
{
    public interface IRepaymentService
    {
        Task<IEnumerable<Repayment>> GetAll();
        Task<Repayment> GetById(int id);
        Task<Repayment> Add(Repayment repayment);
        Task<Repayment> Update(Repayment repayment);
        Task Delete(int id);
    }
}
