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
    public class LkpStatusController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public LkpStatusController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLkpStatus> Get()
        {
            return _context.DeepakLkpStatuses.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLkpStatus GetData(int id)
        {

            var data = _context.DeepakLkpStatuses.Where(a => a.StatusId == id).FirstOrDefault();
            return data;

        }
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLkpStatus tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLkpStatuses.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLkpStatus tbl)
        {
            try
            {
                if (id != tbl.StatusId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLkpStatuses.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.StatusId = tbl.StatusId;
                    UserUpdate.Status = tbl.Status;
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
            var data = await _context.DeepakLkpStatuses.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLkpStatuses.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
