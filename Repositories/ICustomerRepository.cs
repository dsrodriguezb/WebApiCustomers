using WebApiCustomers.Models;

namespace WebApiCustomers.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task PatchCustomer(int id, Customer customer);
        Task DeleteCustomer(int id);
    }
}
