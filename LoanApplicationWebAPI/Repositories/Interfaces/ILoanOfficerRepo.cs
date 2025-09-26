using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface ILoanOfficerRepo
    {
        Task<IEnumerable<LoanOfficer>> GetAll();
        Task<LoanOfficer> GetById(int id);
        Task<LoanOfficer> Add(LoanOfficer officer);
        Task<LoanOfficer> Update(LoanOfficer officer);
        Task Delete(int id);

        
    }
}
