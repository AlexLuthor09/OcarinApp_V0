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
    public class Responsables_TachesController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public Responsables_TachesController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Responsables_Taches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsables_Taches>>> GetResponsables_Taches()
        {
          if (_context.Responsables_Taches == null)
          {
              return NotFound();
          }
            return await _context.Responsables_Taches.ToListAsync();
        }

        // GET: api/Responsables_Taches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsables_Taches>> GetResponsables_Taches(int id)
        {
          if (_context.Responsables_Taches == null)
          {
              return NotFound();
          }
            var responsables_Taches = await _context.Responsables_Taches.FindAsync(id);

            if (responsables_Taches == null)
            {
                return NotFound();
            }

            return responsables_Taches;
        }

        // PUT: api/Responsables_Taches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponsables_Taches(int id, Responsables_Taches responsables_Taches)
        {
            if (id != responsables_Taches.ID)
            {
                return BadRequest();
            }

            _context.Entry(responsables_Taches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Responsables_TachesExists(id))
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

        // POST: api/Responsables_Taches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Responsables_Taches>> PostResponsables_Taches(Responsables_Taches responsables_Taches)
        {
          if (_context.Responsables_Taches == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Responsables_Taches'  is null.");
          }
            _context.Responsables_Taches.Add(responsables_Taches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponsables_Taches", new { id = responsables_Taches.ID }, responsables_Taches);
        }

        // DELETE: api/Responsables_Taches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsables_Taches(int id)
        {
            if (_context.Responsables_Taches == null)
            {
                return NotFound();
            }
            var responsables_Taches = await _context.Responsables_Taches.FindAsync(id);
            if (responsables_Taches == null)
            {
                return NotFound();
            }

            _context.Responsables_Taches.Remove(responsables_Taches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Responsables_TachesExists(int id)
        {
            return (_context.Responsables_Taches?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
