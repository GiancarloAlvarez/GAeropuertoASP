using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GAeropuerto.Models;

namespace GAeropuerto.Controllers
{
    public class PilotosController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public PilotosController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: Pilotos
        public async Task<IActionResult> Index()
        {
            var bDGAeropuertoContext = _context.Pilotos.Include(p => p.IdPersonaNavigation);
            return View(await bDGAeropuertoContext.ToListAsync());
        }

        // GET: Pilotos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pilotos == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdPiloto == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // GET: Pilotos/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            return View();
        }

        // POST: Pilotos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPiloto,IdPersona,Licencia,HorasVuelo,FechaRev")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(piloto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", piloto.IdPersona);
            return View(piloto);
        }

        // GET: Pilotos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pilotos == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", piloto.IdPersona);
            return View(piloto);
        }

        // POST: Pilotos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPiloto,IdPersona,Licencia,HorasVuelo,FechaRev")] Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoExists(piloto.IdPiloto))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", piloto.IdPersona);
            return View(piloto);
        }

        // GET: Pilotos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pilotos == null)
            {
                return NotFound();
            }

            var piloto = await _context.Pilotos
                .Include(p => p.IdPersonaNavigation)
                .FirstOrDefaultAsync(m => m.IdPiloto == id);
            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // POST: Pilotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pilotos == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.Pilotos'  is null.");
            }
            var piloto = await _context.Pilotos.FindAsync(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotoExists(int id)
        {
          return (_context.Pilotos?.Any(e => e.IdPiloto == id)).GetValueOrDefault();
        }
    }
}
