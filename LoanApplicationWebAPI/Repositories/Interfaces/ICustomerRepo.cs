using LoanApplicationWebAPI.Models;

namespace LoanApplicationWebAPI.Repositories.Interfaces
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task Delete(int id);

      

    }
}
