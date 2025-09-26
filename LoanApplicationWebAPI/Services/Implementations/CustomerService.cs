using LoanApplicationWebAPI.Models;
using LoanApplicationWebAPI.Repositories.Interfaces;
using LoanApplicationWebAPI.Repositories;
using LoanApplicationWebAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanApplicationWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepo.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepo.GetById(id);
        }

        public async Task<Customer> Add(Customer customer)
        {
            return await _customerRepo.Add(customer);
        }

        public async Task<Customer> Update(Customer customer)
        {
            return await _customerRepo.Update(customer);
        }

        public async Task Delete(int id)
        {
            await _customerRepo.Delete(id);
        }
    }
}
