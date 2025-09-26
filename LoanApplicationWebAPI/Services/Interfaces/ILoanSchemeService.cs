using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Services.Interfaces
{
    public interface ILoanSchemeService
    {

        Task<IEnumerable<LoanScheme>> GetAll();
        Task<LoanScheme> GetById(int id);
        Task<LoanScheme> Add(LoanScheme scheme);
        Task<LoanScheme> Update(LoanScheme scheme);
        Task Delete(int id);
    }
}
