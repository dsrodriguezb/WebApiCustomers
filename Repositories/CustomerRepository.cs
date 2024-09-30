using Microsoft.EntityFrameworkCore;
using WebApiCustomers.Context;
using WebApiCustomers.Models;

namespace WebApiCustomers.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.Where(c => c.Active).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer != null ? customer : throw new KeyNotFoundException($"Customer with ID {id} not found.");
        }

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var cliente = await _context.Customers.FindAsync(id);
            if (cliente != null)
            {
                _context.Customers.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

         public async Task PatchCustomer(int id, Customer customer)
         {
            var customerr = await _context.Customers.FindAsync(id);
            if (customerr == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            // Actualiza solo los campos que no son nulos
            if (customer.Name != null)
                customerr.Name = customer.Name;

            if (customer.Email != null)
                customerr.Email = customer.Email;

            if (customer.Active != default)
                customerr.Active = customer.Active;

            // Agrega otros campos que necesites actualizar

            await _context.SaveChangesAsync();
        }

    }
}
