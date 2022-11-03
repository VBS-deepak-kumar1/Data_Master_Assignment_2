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
    public class LkpAddressController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public LkpAddressController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLkpAddress> Get()
        {
            return _context.DeepakLkpAddresses.ToList();
        }
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLkpAddress GetData(int id)
        {

            var data = _context.DeepakLkpAddresses.Where(a => a.Zid == id).FirstOrDefault();
            return data;

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLkpAddress tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLkpAddresses.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLkpAddress tbl)
        {
            try
            {
                if (id != tbl.Zid)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLkpAddresses.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.Zid = tbl.Zid;
                    UserUpdate.ZipCode = tbl.ZipCode;
                    UserUpdate.CustId = tbl.CustId;
                   
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
            var data = await _context.DeepakLkpAddresses.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLkpAddresses.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
