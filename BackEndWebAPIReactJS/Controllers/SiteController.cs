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
    public class SiteController : ControllerBase
    {
        private readonly AdventureWorks2017Context _context;
        public SiteController(AdventureWorks2017Context context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<DeepakSite> Get()
        {
            return _context.DeepakSites.ToList();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public DeepakSite GetData(int id)
        {

            var data = _context.DeepakSites.Where(a => a.SiteId == id).FirstOrDefault();
            return data;

        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] DeepakSite tbl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            _context.DeepakSites.Add(tbl);
            _context.SaveChanges();

            return Ok();
        }
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DeepakSite site)
        {
            try
            {
                if (id != site.SiteId)
                {
                    return BadRequest("Id mismatch");
                }
                var UserUpdate = await _context.DeepakSites.FindAsync(id);
                if (UserUpdate != null)
                {
                    UserUpdate.SiteId = site.SiteId;
                    UserUpdate.SiteName = site.SiteName;
                    UserUpdate.StartDate = site.StartDate;
                    UserUpdate.EndDate = site.EndDate;
                    UserUpdate.ProjectManager = site.ProjectManager;
                    UserUpdate.RealEstateSpecialist = site.RealEstateSpecialist;
                    UserUpdate.FieldCoordinator = site.FieldCoordinator;
                    UserUpdate.SiteAcqVendor = site.SiteAcqVendor;
                    UserUpdate.CivilVendor = site.CivilVendor;
                    UserUpdate.ConstructionVendor = site.ConstructionVendor;
                    UserUpdate.ConstructionVendor = site.ConstructionVendor;
                    UserUpdate.AeFirm = site.AeFirm;
                    UserUpdate.CustId = site.CustId;
                    

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
            var data = await _context.DeepakSites.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.DeepakSites.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
