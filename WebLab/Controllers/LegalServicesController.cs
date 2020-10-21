using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLab.DAL.Data;
using WebLab.DAL.Entities;

namespace WebLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LegalServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LegalServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalService>>> GetLegalServices(int? group)
        {
            return await _context.LegalServices.Where(d => !group.HasValue
            || d.LegalServiceGroupId.Equals(group.Value))?.ToListAsync();
        }

        // GET: api/LegalServices
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<LegalService>>> GetLegalServices()
        //{
        //    return await _context.LegalServices.ToListAsync();
        //}

        // GET: api/LegalServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalService>> GetLegalService(int id)
        {
            var legalService = await _context.LegalServices.FindAsync(id);

            if (legalService == null)
            {
                return NotFound();
            }

            return legalService;
        }

        // PUT: api/LegalServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalService(int id, LegalService legalService)
        {
            if (id != legalService.LegalServiceId)
            {
                return BadRequest();
            }

            _context.Entry(legalService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LegalServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LegalService>> PostLegalService(LegalService legalService)
        {
            _context.LegalServices.Add(legalService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegalService", new { id = legalService.LegalServiceId }, legalService);
        }

        // DELETE: api/LegalServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LegalService>> DeleteLegalService(int id)
        {
            var legalService = await _context.LegalServices.FindAsync(id);
            if (legalService == null)
            {
                return NotFound();
            }

            _context.LegalServices.Remove(legalService);
            await _context.SaveChangesAsync();

            return legalService;
        }

        private bool LegalServiceExists(int id)
        {
            return _context.LegalServices.Any(e => e.LegalServiceId == id);
        }
    }
}
