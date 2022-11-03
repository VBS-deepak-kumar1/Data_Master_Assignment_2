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
    public class LkpSiteTypeController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public LkpSiteTypeController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLkpSiteType> Get()
        {
            return _context.DeepakLkpSiteTypes.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLkpSiteType GetData(int id)
        {

            var data = _context.DeepakLkpSiteTypes.Where(a => a.SiteTypeId == id).FirstOrDefault();
            return data;

        }
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLkpSiteType tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLkpSiteTypes.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLkpSiteType tbl)
        {
            try
            {
                if (id != tbl.SiteTypeId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLkpSiteTypes.FindAsync(id);
                if (UserUpdate != null)
                {

                    UserUpdate.SiteTypeId = tbl.SiteTypeId;
                    UserUpdate.CustId = tbl.CustId;
                    UserUpdate.SiteType = tbl.SiteType;
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
            var data = await _context.DeepakLkpSiteTypes.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLkpSiteTypes.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
