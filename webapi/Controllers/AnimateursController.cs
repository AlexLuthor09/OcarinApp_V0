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
    public class AnimateursController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public AnimateursController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Animateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animateurs>>> GetAnimateurs()
        {
          
          if (_context.Animateurs == null)
          {
              return NotFound();
          }
            
            return await _context.Animateurs.ToListAsync();
        }

        // GET: api/Animateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animateurs>> GetAnimateurs(int id)
        {
          if (_context.Animateurs == null)
          {
              return NotFound();
          }
            var animateurs = await _context.Animateurs.FindAsync(id);

            if (animateurs == null)
            {
                return NotFound();
            }

            return animateurs;
        }

        // PUT: api/Animateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimateurs(int id, Animateurs animateurs)
        {
            if (id != animateurs.ID)
            {
                return BadRequest();
            }

            _context.Entry(animateurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimateursExists(id))
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

        // POST: api/Animateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animateurs>> PostAnimateurs(Animateurs animateurs)
        {
          if (_context.Animateurs == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Animateurs'  is null.");
          }
            _context.Animateurs.Add(animateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimateurs", new { id = animateurs.ID }, animateurs);
        }

        // DELETE: api/Animateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimateurs(int id)
        {
            if (_context.Animateurs == null)
            {
                return NotFound();
            }
            var animateurs = await _context.Animateurs.FindAsync(id);
            if (animateurs == null)
            {
                return NotFound();
            }

            _context.Animateurs.Remove(animateurs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimateursExists(int id)
        {
            return (_context.Animateurs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
