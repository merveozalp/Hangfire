using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Papara.Core.Entity;
using Papara.Core.Enums;
using Papara.Core.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly Func<CacheTech, ICacheService> _cacheService;

        public CustomerController(ICustomerRepository repository, Func<CacheTech, ICacheService> cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _repository.GetAllAsync();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(customer);
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            await _repository.AddAsync(customer);
            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _repository.DeleteAsync(customer);
            return Ok(customer);
        }       
    }
}
