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
    public class TachesController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public TachesController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Taches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taches>>> GetTaches()
        {
          if (_context.Taches == null)
          {
              return NotFound();
          }
            return await _context.Taches.ToListAsync();
        }

        // GET: api/Taches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taches>> GetTaches(int id)
        {
          if (_context.Taches == null)
          {
              return NotFound();
          }
            var taches = await _context.Taches.FindAsync(id);

            if (taches == null)
            {
                return NotFound();
            }

            return taches;
        }

        // PUT: api/Taches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaches(int id, Taches taches)
        {
            if (id != taches.ID)
            {
                return BadRequest();
            }

            _context.Entry(taches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TachesExists(id))
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

        // POST: api/Taches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taches>> PostTaches(Taches taches)
        {
          if (_context.Taches == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Taches'  is null.");
          }
            _context.Taches.Add(taches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaches", new { id = taches.ID }, taches);
        }

        // DELETE: api/Taches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaches(int id)
        {
            if (_context.Taches == null)
            {
                return NotFound();
            }
            var taches = await _context.Taches.FindAsync(id);
            if (taches == null)
            {
                return NotFound();
            }

            _context.Taches.Remove(taches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TachesExists(int id)
        {
            return (_context.Taches?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
