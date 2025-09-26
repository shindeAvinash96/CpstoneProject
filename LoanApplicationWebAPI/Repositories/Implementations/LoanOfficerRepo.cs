using LoanApplicationWebAPI.Data;
using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Repository
{
    public class LoanOfficerRepo : ILoanOfficerRepo
    {
        private readonly AppDbContext _context;

        public LoanOfficerRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoanOfficer>> GetAll()
        {
            return await _context.LoanOfficers.ToListAsync();
        }

        public async Task<LoanOfficer> GetById(int id)
        {
            return await _context.LoanOfficers.FindAsync(id);
        }

        public async Task<LoanOfficer> Add(LoanOfficer officer)
        {
            await _context.LoanOfficers.AddAsync(officer);
            await _context.SaveChangesAsync();
            return officer;
        }

        public async Task<LoanOfficer> Update(LoanOfficer officer)
        {
            _context.LoanOfficers.Update(officer);
            await _context.SaveChangesAsync();
            return officer;
        }

        public async Task Delete(int id)
        {
            var officer = await GetById(id);
            if (officer != null)
            {
                _context.LoanOfficers.Remove(officer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
