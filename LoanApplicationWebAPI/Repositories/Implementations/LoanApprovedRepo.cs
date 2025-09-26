using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class LoanApprovedRepo : ILoanApprovedRepo
    {
        private readonly AppDbContext _context;

        public LoanApprovedRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanApproved>> GetAll()
        {
            return await _context.LoanApproved.ToListAsync();
        }

        public async Task<LoanApproved> GetById(int id)
        {
            return await _context.LoanApproved.FindAsync(id);
        }

        public async Task<LoanApproved> Add(LoanApproved approved)
        {
            await _context.LoanApproved.AddAsync(approved);
            await _context.SaveChangesAsync();
            return approved;
        }

        public async Task<LoanApproved> Update(LoanApproved approved)
        {
            _context.LoanApproved.Update(approved);
            await _context.SaveChangesAsync();
            return approved;
        }

        public async Task Delete(int id)
        {
            var approved = await GetById(id);
            if (approved != null)
            {
                _context.LoanApproved.Remove(approved);
                await _context.SaveChangesAsync();
            }
        }
    }
}
