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
    public class LKpManagerController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public LKpManagerController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLkpManager> Get()
        {
            return _context.DeepakLkpManagers.ToList();
        }
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLkpManager GetData(int id)
        {

            var data = _context.DeepakLkpManagers.Where(a => a.AemanagerId == id).FirstOrDefault();
            return data;

        }
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLkpManager tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLkpManagers.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLkpManager tbl)
        {
            try
            {
                if (id != tbl.AemanagerId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLkpManagers.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.AemanagerId = tbl.AemanagerId;
                    UserUpdate.ConstructionManagerId = tbl.ConstructionManagerId;
                    UserUpdate.ClientCm = tbl.ClientCm;
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
            var data = await _context.DeepakLkpManagers.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLkpManagers.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
