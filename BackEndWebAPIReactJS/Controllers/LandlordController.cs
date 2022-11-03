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
    public class LandlordController : ControllerBase
    {

        private readonly AdventureWorks2017Context _context;
        public LandlordController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakLandlord> Get()
        {
            return _context.DeepakLandlords.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakLandlord GetData(int id)
        {

            var data = _context.DeepakLandlords.Where(a => a.LandlordId == id).FirstOrDefault();
            return data;

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakLandlord data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakLandlords.Add(data);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakLandlord tbl)
        {
            try
            {
                if (id != tbl.LandlordId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakLandlords.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.LandlordId = tbl.LandlordId;
                    UserUpdate.LandlordName = tbl.LandlordName;
                    UserUpdate.LandlordType = tbl.LandlordType;
                    UserUpdate.Latitude = tbl.Latitude;
                    UserUpdate.Longitude = tbl.Longitude;
                    UserUpdate.LandlordContactInfo = tbl.LandlordContactInfo;
                    UserUpdate.Jurisdiction = UserUpdate.Jurisdiction;
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
            var data = await _context.DeepakLandlords.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakLandlords.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
