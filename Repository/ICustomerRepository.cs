using WebApplicationDemo.Models;

namespace WebApplicationDemo.Repository
{
    public interface ICustomerRepository
    {
        Task AddCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAll();
    }
}
