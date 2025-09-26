using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepo _loanApplicationRepo;

        public LoanApplicationService(ILoanApplicationRepo loanApplicationRepo)
        {
            _loanApplicationRepo = loanApplicationRepo;
        }

        public async Task<IEnumerable<LoanApplication>> GetAll() => await _loanApplicationRepo.GetAll();

        public async Task<LoanApplication> GetById(int id) => await _loanApplicationRepo.GetById(id);

        public async Task<LoanApplication> Add(LoanApplication application) => await _loanApplicationRepo.Add(application);

        public async Task<LoanApplication> Update(LoanApplication application) => await _loanApplicationRepo.Update(application);

        public async Task Delete(int id) => await _loanApplicationRepo.Delete(id);
    }
}
