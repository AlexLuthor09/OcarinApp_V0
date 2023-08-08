using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OcarinAPI.Data;
using OcarinAPI.Models;

namespace OcarinAPI.Controllers
{
    public class AnimateursController : Controller
    {
        private readonly OcarinaDBContext _context;

        public AnimateursController(OcarinaDBContext context)
        {
            _context = context;
        }

        // GET: Animateurs
        public async Task<IActionResult> Index()
        {
              return _context.Animateurs != null ? 
                          View(await _context.Animateurs.ToListAsync()) :
                          Problem("Entity set 'OcarinaDBContext.Animateurs'  is null.");
        }

        // GET: Animateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animateurs == null)
            {
                return NotFound();
            }

            var animateurs = await _context.Animateurs
                .FirstOrDefaultAsync(m => m.ID_animateur == id);
            if (animateurs == null)
            {
                return NotFound();
            }

            return View(animateurs);
        }

        // GET: Animateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_animateur,Prenom,Nom,ResponsableTrancheAge,DateNaissance,Adresse,NumeroTelephone,Email,Allergie,Commentaire,AnneeFormation")] Animateurs animateurs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animateurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animateurs);
        }

        // GET: Animateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animateurs == null)
            {
                return NotFound();
            }

            var animateurs = await _context.Animateurs.FindAsync(id);
            if (animateurs == null)
            {
                return NotFound();
            }
            return View(animateurs);
        }

        // POST: Animateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_animateur,Prenom,Nom,ResponsableTrancheAge,DateNaissance,Adresse,NumeroTelephone,Email,Allergie,Commentaire,AnneeFormation")] Animateurs animateurs)
        {
            if (id != animateurs.ID_animateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animateurs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimateursExists(animateurs.ID_animateur))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(animateurs);
        }

        // GET: Animateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animateurs == null)
            {
                return NotFound();
            }

            var animateurs = await _context.Animateurs
                .FirstOrDefaultAsync(m => m.ID_animateur == id);
            if (animateurs == null)
            {
                return NotFound();
            }

            return View(animateurs);
        }

        // POST: Animateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animateurs == null)
            {
                return Problem("Entity set 'OcarinaDBContext.Animateurs'  is null.");
            }
            var animateurs = await _context.Animateurs.FindAsync(id);
            if (animateurs != null)
            {
                _context.Animateurs.Remove(animateurs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimateursExists(int id)
        {
          return (_context.Animateurs?.Any(e => e.ID_animateur == id)).GetValueOrDefault();
        }
    }
}
