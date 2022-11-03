using BackEndWebAPIReactJS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndWebAPIReactJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteAddressController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public SiteAddressController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakSiteAddress> Get()
        {
            return _context.DeepakSiteAddresses.ToList();
        }
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakSiteAddress GetData(int id)
        {

            var data = _context.DeepakSiteAddresses.Where(a => a.CustId == id).FirstOrDefault();
            return data;

        }
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakSiteAddress tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakSiteAddresses.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakSiteAddress tbl)
        {
            try
            {
                if (id != tbl.CustId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakSiteAddresses.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.CustId = tbl.CustId;
                    UserUpdate.Street = tbl.Street;
                    UserUpdate.ZipCode = tbl.State;
                    UserUpdate.City = tbl.City;
                    UserUpdate.Country = tbl.Country;
                    UserUpdate.State = tbl.State;

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
            var data = await _context.DeepakSiteAddresses.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakSiteAddresses.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
