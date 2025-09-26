using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class LoanSchemeService : ILoanSchemeService
    {
        private readonly ILoanSchemeRepo _loanSchemeRepo;

        public LoanSchemeService(ILoanSchemeRepo loanSchemeRepo)
        {
            _loanSchemeRepo = loanSchemeRepo;
        }

        public async Task<IEnumerable<LoanScheme>> GetAll() => await _loanSchemeRepo.GetAll();

        public async Task<LoanScheme> GetById(int id) => await _loanSchemeRepo.GetById(id);

        public async Task<LoanScheme> Add(LoanScheme scheme) => await _loanSchemeRepo.Add(scheme);

        public async Task<LoanScheme> Update(LoanScheme scheme) => await _loanSchemeRepo.Update(scheme);

        public async Task Delete(int id) => await _loanSchemeRepo.Delete(id);
    }
}
