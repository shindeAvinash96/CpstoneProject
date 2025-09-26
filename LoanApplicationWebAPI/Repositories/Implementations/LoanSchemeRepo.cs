using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class LoanSchemeRepo : ILoanSchemeRepo
    {
        private readonly AppDbContext _context;

        public LoanSchemeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanScheme>> GetAll()
        {
            return await _context.LoanSchemes.ToListAsync();
        }

        public async Task<LoanScheme> GetById(int id)
        {
            return await _context.LoanSchemes.FindAsync(id);
        }

        public async Task<LoanScheme> Add(LoanScheme scheme)
        {
            await _context.LoanSchemes.AddAsync(scheme);
            await _context.SaveChangesAsync();
            return scheme;
        }

        public async Task<LoanScheme> Update(LoanScheme scheme)
        {
            _context.LoanSchemes.Update(scheme);
            await _context.SaveChangesAsync();
            return scheme;
        }

        public async Task Delete(int id)
        {
            var scheme = await GetById(id);
            if (scheme != null)
            {
                _context.LoanSchemes.Remove(scheme);
                await _context.SaveChangesAsync();
            }
        }
    }
}
