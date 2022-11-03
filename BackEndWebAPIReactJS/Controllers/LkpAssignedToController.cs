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
    public class LkpAssignedToController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public LkpAssignedToController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLkpAssignedTo> Get()
        {
            return _context.DeepakLkpAssignedTos.ToList();
        }
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLkpAssignedTo GetData(int id)
        {

            var data = _context.DeepakLkpAssignedTos.Where(a => a.Aid == id).FirstOrDefault();
            return data;

        }
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLkpAssignedTo tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLkpAssignedTos.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLkpAssignedTo tbl)
        {
            try
            {
                if (id != tbl.Aid)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLkpAssignedTos.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.Aid = tbl.Aid;
                    UserUpdate.AssignedTo = tbl.AssignedTo;
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
            var data = await _context.DeepakLkpAssignedTos.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLkpAssignedTos.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
