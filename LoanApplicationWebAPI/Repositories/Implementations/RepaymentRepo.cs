using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class RepaymentRepo : IRepaymentRepo
    {
        private readonly AppDbContext _context;

        public RepaymentRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Repayment>> GetAll()
        {
            return await _context.Repayments.ToListAsync();
        }

        public async Task<Repayment> GetById(int id)
        {
            return await _context.Repayments.FindAsync(id);
        }

        public async Task<Repayment> Add(Repayment repayment)
        {
            await _context.Repayments.AddAsync(repayment);
            await _context.SaveChangesAsync();
            return repayment;
        }

        public async Task<Repayment> Update(Repayment repayment)
        {
            _context.Repayments.Update(repayment);
            await _context.SaveChangesAsync();
            return repayment;
        }

        public async Task Delete(int id)
        {
            var repayment = await GetById(id);
            if (repayment != null)
            {
                _context.Repayments.Remove(repayment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
