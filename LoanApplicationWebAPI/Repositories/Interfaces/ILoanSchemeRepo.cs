using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface ILoanSchemeRepo
    {
        Task<IEnumerable<LoanScheme>> GetAll();
        Task<LoanScheme> GetById(int id);
        Task<LoanScheme> Add(LoanScheme scheme);
        Task<LoanScheme> Update(LoanScheme scheme);
        Task Delete(int id);
    }
}
