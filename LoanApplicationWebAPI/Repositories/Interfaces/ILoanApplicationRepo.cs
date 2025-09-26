using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface ILoanApplicationRepo
    {
        Task<IEnumerable<LoanApplication>> GetAll();
        Task<LoanApplication> GetById(int id);
        Task<LoanApplication> Add(LoanApplication application);
        Task<LoanApplication> Update(LoanApplication application);
        Task Delete(int id);
    }
}
