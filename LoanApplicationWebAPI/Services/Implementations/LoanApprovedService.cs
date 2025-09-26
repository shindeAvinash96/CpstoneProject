using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class LoanApprovedService : ILoanApprovedService
    {
        private readonly ILoanApprovedRepo _loanApprovedRepo;

        public LoanApprovedService(ILoanApprovedRepo loanApprovedRepo)
        {
            _loanApprovedRepo = loanApprovedRepo;
        }

        public async Task<IEnumerable<LoanApproved>> GetAll() => await _loanApprovedRepo.GetAll();

        public async Task<LoanApproved> GetById(int id) => await _loanApprovedRepo.GetById(id);

        public async Task<LoanApproved> Add(LoanApproved approved) => await _loanApprovedRepo.Add(approved);

        public async Task<LoanApproved> Update(LoanApproved approved) => await _loanApprovedRepo.Update(approved);

        public async Task Delete(int id) => await _loanApprovedRepo.Delete(id);
    }
}
