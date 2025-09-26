using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface IRepaymentRepo
    {
        Task<IEnumerable<Repayment>> GetAll();
        Task<Repayment> GetById(int id);
        Task<Repayment> Add(Repayment repayment);
        Task<Repayment> Update(Repayment repayment);
        Task Delete(int id);
    }
}
