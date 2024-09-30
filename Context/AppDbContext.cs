using Microsoft.EntityFrameworkCore;
using WebApiCustomers.Models;

namespace WebApiCustomers.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
