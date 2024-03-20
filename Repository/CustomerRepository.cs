using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarlosDbContext _context;

        public CustomerRepository(CarlosDbContext context)
        {
            _context = context;
        }
        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
