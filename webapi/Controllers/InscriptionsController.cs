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
    public class InscriptionsController : ControllerBase
    {
        private readonly OcarinAPIContext _context;

        public InscriptionsController(OcarinAPIContext context)
        {
            _context = context;
        }

        // GET: api/Inscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscription>>> GetInscription()
        {
          if (_context.Inscription == null)
          {
              return NotFound();
          }
            return await _context.Inscription.ToListAsync();
        }

        // GET: api/Inscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscription>> GetInscription(int id)
        {
          if (_context.Inscription == null)
          {
              return NotFound();
          }
            var inscription = await _context.Inscription.FindAsync(id);

            if (inscription == null)
            {
                return NotFound();
            }

            return inscription;
        }

        // PUT: api/Inscriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscription(int id, Inscription inscription)
        {
            if (id != inscription.ID)
            {
                return BadRequest();
            }

            _context.Entry(inscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscriptionExists(id))
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

        // POST: api/Inscriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscription>> PostInscription(Inscription inscription)
        {
          if (_context.Inscription == null)
          {
              return Problem("Entity set 'OcarinAPIContext.Inscription'  is null.");
          }
            _context.Inscription.Add(inscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscription", new { id = inscription.ID }, inscription);
        }

        // DELETE: api/Inscriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            if (_context.Inscription == null)
            {
                return NotFound();
            }
            var inscription = await _context.Inscription.FindAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }

            _context.Inscription.Remove(inscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscriptionExists(int id)
        {
            return (_context.Inscription?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
