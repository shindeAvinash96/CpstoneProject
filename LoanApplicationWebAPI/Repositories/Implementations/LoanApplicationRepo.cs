using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class LoanApplicationRepo : ILoanApplicationRepo
    {
        private readonly AppDbContext _context;

        public LoanApplicationRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanApplication>> GetAll()
        {
            return await _context.LoanApplications.ToListAsync();
        }

        public async Task<LoanApplication> GetById(int id)
        {
            return await _context.LoanApplications.FindAsync(id);
        }

        public async Task<LoanApplication> Add(LoanApplication application)
        {
            await _context.LoanApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<LoanApplication> Update(LoanApplication application)
        {
            _context.LoanApplications.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task Delete(int id)
        {
            var application = await GetById(id);
            if (application != null)
            {
                _context.LoanApplications.Remove(application);
                await _context.SaveChangesAsync();
            }
        }
    }
}
