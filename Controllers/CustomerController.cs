using GenericRepo.GenRepository;
using GenericRepo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GenericRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private IDataRepository<Customer> _repository;
        public CustomersController(IDataRepository<Customer> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>  
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> customers = _repository.GetAll();
            return Ok(customers);
        }

        // GET api/<controller>/5  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Customer customer = _repository.Get(id);

            if (customer == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(customer);
        }

        // POST api/<controller>  
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer is Null");
            }
            _repository.Insert(customer);
            return Ok(customer);
        }

        // PUT api/<controller>/5  
        [HttpPut()]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            _repository.Change(customer);
            return Ok();
        }

        // DELETE api/<controller>/5  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _repository.Get(id);
            if (customer == null)
            {
                return BadRequest("Customer is not found");
            }
            _repository.Delete(customer);
            return Ok();
        }
    }
}
