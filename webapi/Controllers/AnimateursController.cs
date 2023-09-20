using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using OcarinAPI.Data;
using OcarinAPI.Models;
using OcarinAPI.Models.ModelsNotDB;

namespace OcarinAPI.Controllers
{
    [Route("OcarinApi/[controller]")]
    [ApiController]
    public class AnimateursController : ControllerBase
    {
        private readonly OcarinaDBContext _context;

        public AnimateursController(OcarinaDBContext context)
        {
            _context = context;
        }

        // GET: OcarinApi/Animateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animateurs>>> GetAnimateurs()
        {
          if (_context.Animateurs == null)
          {
              return NotFound();
          }

            return await _context.Animateurs.ToListAsync();
        }
        // GET: OcarinApi/Animateurs/[ID_plaine]
        [HttpGet("{ID_plaines}")]
        public object GetAnimateurs(int ID_plaines)
        {
          if (_context.Animateurs == null)
          {
              return NotFound();
          }
            var query = from a in _context.Animateurs
                        join ap in _context.Animateurs_Plaines
                        on a.ID_animateur equals ap.ID_animateur
                        where ap.ID_plaine == ID_plaines
                        select new
                        {
                            a.ID_animateur,
                            ap.ID_plaine,
                            a.Prenom,
                            a.Nom,
                            a.NumeroTelephone,
                            a.Adresse,
                            a.Email,
                            a.Allergie,
                            a.Commentaire,
                            a.AnneeFormation,
                            ap.ResponsableTrancheAge,
                            ap.FicheSante
                           
                        };

            var animateurs =  query.ToList();

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
            if (id != animateurs.ID_animateur)
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
              return Problem("Entity set 'OcarinaDBContext.Animateurs'  is null.");
          }
            _context.Animateurs.Add(animateurs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimateurs", new { id = animateurs.ID_animateur }, animateurs);
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
            return (_context.Animateurs?.Any(e => e.ID_animateur == id)).GetValueOrDefault();
        }
    }
}
