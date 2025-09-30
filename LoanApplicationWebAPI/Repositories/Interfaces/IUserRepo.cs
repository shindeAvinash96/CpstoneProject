using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
      public interface IUserRepo
        {
            Task<IEnumerable<User>> GetAll();
            Task<User> GetById(int id);
            Task<User> Add(User user);
            Task<User> Update(User user);
            Task Delete(int id);

            // Login method
            Task<LoginResponseViewModel> LoginAsync(LoginViewModel login);
        }

    }

