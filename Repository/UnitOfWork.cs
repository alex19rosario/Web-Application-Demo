using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    //THIS IS THE INTERFACE
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        Task Complete();
    }

    //THIS IS THE IMPLEMENTATION
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarlosDbContext _context;
        public ICustomerRepository CustomerRepository { get; private set; }
        public UnitOfWork(CarlosDbContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(_context);
        }

        public async Task Complete()
        {
            _context.SaveChanges();
        }
    }
}
