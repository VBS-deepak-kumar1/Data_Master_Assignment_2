using BackEndWebAPIReactJS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndWebAPIReactJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly AdventureWorks2017Context _context;
        public CustomerController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakCustomer> Get()
        {
            return _context.DeepakCustomers.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakCustomer GetData(int id)
        {

            var data = _context.DeepakCustomers.Where(a => a.CustomerId == id).FirstOrDefault();
            return data;

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakCustomer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakCustomers.Add(customer);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakCustomer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakCustomers.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.CustomerId = customer.CustomerId;
                    UserUpdate.CustomerMarket = customer.CustomerMarket;
                    UserUpdate.CustomerRegion = customer.CustomerRegion;
                    UserUpdate.CustomerSite = customer.CustomerSite;
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error in data retrieval");
            }
        }   

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.DeepakCustomers.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakCustomers.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
