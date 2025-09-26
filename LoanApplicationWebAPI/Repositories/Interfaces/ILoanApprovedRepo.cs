using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface ILoanApprovedRepo
    {
        Task<IEnumerable<LoanApproved>> GetAll();
        Task<LoanApproved> GetById(int id);
        Task<LoanApproved> Add(LoanApproved approved);
        Task<LoanApproved> Update(LoanApproved approved);
        Task Delete(int id);
    }
}
