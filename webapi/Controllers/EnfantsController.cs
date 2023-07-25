using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OcarinAPI.Data;
using OcarinAPI.Models;

namespace OcarinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfantsController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public EnfantsController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Enfants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enfants>>> GetEnfants()
        {
          if (_context.Enfants == null)
          {
              return NotFound();
          }
            return await _context.Enfants.ToListAsync();
        }

        // GET: api/Enfants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enfants>> GetEnfants(int id)
        {
          if (_context.Enfants == null)
          {
              return NotFound();
          }
            var enfants = await _context.Enfants.FindAsync(id);

            if (enfants == null)
            {
                return NotFound();
            }

            return enfants;
        }

        // PUT: api/Enfants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnfants(int id, Enfants enfants)
        {
            if (id != enfants.ID)
            {
                return BadRequest();
            }

            _context.Entry(enfants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfantsExists(id))
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

        // POST: api/Enfants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Enfants>> PostEnfants(Enfants enfants)
        {
          if (_context.Enfants == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Enfants'  is null.");
          }
            _context.Enfants.Add(enfants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnfants", new { id = enfants.ID }, enfants);
        }

        // DELETE: api/Enfants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfants(int id)
        {
            if (_context.Enfants == null)
            {
                return NotFound();
            }
            var enfants = await _context.Enfants.FindAsync(id);
            if (enfants == null)
            {
                return NotFound();
            }

            _context.Enfants.Remove(enfants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfantsExists(int id)
        {
            return (_context.Enfants?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
