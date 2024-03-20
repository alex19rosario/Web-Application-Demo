using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;

namespace WebApplicationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Customer
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAll();
            return Ok(customers);
        }

        // POST: /Customer
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            await _unitOfWork.CustomerRepository.AddCustomer(customer);
            await _unitOfWork.Complete();
            return CreatedAtAction(nameof(GetAll), new { id = customer.Id }, customer);
        }


    }

}
