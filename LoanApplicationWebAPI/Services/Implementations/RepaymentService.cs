using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class RepaymentService : IRepaymentService
    {
        private readonly IRepaymentRepo _repaymentRepo;

        public RepaymentService(IRepaymentRepo repaymentRepo)
        {
            _repaymentRepo = repaymentRepo;
        }

        public async Task<IEnumerable<Repayment>> GetAll() => await _repaymentRepo.GetAll();

        public async Task<Repayment> GetById(int id) => await _repaymentRepo.GetById(id);

        public async Task<Repayment> Add(Repayment repayment) => await _repaymentRepo.Add(repayment);

        public async Task<Repayment> Update(Repayment repayment) => await _repaymentRepo.Update(repayment);

        public async Task Delete(int id) => await _repaymentRepo.Delete(id);
    }
}
