using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // ---------------- CRUD ----------------
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepo.GetById(id);
        }

        public async Task<User> Add(User user)
        {
            return await _userRepo.Add(user);
        }

        public async Task<User> Update(User user)
        {
            return await _userRepo.Update(user);
        }

        public async Task Delete(int id)
        {
            await _userRepo.Delete(id);
        }

        // ---------------- Login ----------------
        public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel login)
        {
            // Simply call repo's LoginAsync
            return await _userRepo.LoginAsync(login);
        }
    }
}
