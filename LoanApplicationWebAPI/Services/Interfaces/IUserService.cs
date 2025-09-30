using LoanApplicationWebAPI.Models;


namespace LoanApplicationWebAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(int id);

        Task<LoginResponseViewModel> LoginAsync(LoginViewModel login);
    }
}
