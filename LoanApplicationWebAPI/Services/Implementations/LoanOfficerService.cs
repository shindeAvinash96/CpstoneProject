using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class LoanOfficerService : ILoanOfficerService
    {
        private readonly ILoanOfficerRepo _loanOfficerRepo;

        public LoanOfficerService(ILoanOfficerRepo loanOfficerRepo)
        {
            _loanOfficerRepo = loanOfficerRepo;
        }

        public async Task<IEnumerable<LoanOfficer>> GetAll() => await _loanOfficerRepo.GetAll();

        public async Task<LoanOfficer> GetById(int id) => await _loanOfficerRepo.GetById(id);

        public async Task<LoanOfficer> Add(LoanOfficer officer) => await _loanOfficerRepo.Add(officer);

        public async Task<LoanOfficer> Update(LoanOfficer officer) => await _loanOfficerRepo.Update(officer);

        public async Task Delete(int id) => await _loanOfficerRepo.Delete(id);
    }
}
