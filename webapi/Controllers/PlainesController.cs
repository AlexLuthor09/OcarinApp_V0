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
    public class PlainesController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public PlainesController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Plaines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plaines>>> GetPlaines()
        {
          if (_context.Plaines == null)
          {
              return NotFound();
          }
            return await _context.Plaines.ToListAsync();
        }

        // GET: api/Plaines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plaines>> GetPlaines(int id)
        {
          if (_context.Plaines == null)
          {
              return NotFound();
          }
            var plaines = await _context.Plaines.FindAsync(id);

            if (plaines == null)
            {
                return NotFound();
            }

            return plaines;
        }

        // PUT: api/Plaines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaines(int id, Plaines plaines)
        {
            if (id != plaines.ID)
            {
                return BadRequest();
            }

            _context.Entry(plaines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlainesExists(id))
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

        // POST: api/Plaines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plaines>> PostPlaines(Plaines plaines)
        {
          if (_context.Plaines == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Plaines'  is null.");
          }
            _context.Plaines.Add(plaines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaines", new { id = plaines.ID }, plaines);
        }

        // DELETE: api/Plaines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaines(int id)
        {
            if (_context.Plaines == null)
            {
                return NotFound();
            }
            var plaines = await _context.Plaines.FindAsync(id);
            if (plaines == null)
            {
                return NotFound();
            }

            _context.Plaines.Remove(plaines);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlainesExists(int id)
        {
            return (_context.Plaines?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
