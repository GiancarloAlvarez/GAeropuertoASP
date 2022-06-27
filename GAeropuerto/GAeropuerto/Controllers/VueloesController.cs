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
    public class VueloesController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public VueloesController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: Vueloes
        public async Task<IActionResult> Index()
        {
            var bDGAeropuertoContext = _context.Vuelos.Include(v => v.IdAvionNavigation).Include(v => v.IdPilotoNavigation);
            return View(await bDGAeropuertoContext.ToListAsync());
        }

        // GET: Vueloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vuelos == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelos
                .Include(v => v.IdAvionNavigation)
                .Include(v => v.IdPilotoNavigation)
                .FirstOrDefaultAsync(m => m.IdVuelo == id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return View(vuelo);
        }

        // GET: Vueloes/Create
        public IActionResult Create()
        {
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion");
            ViewData["IdPiloto"] = new SelectList(_context.Pilotos, "IdPiloto", "IdPiloto");
            return View();
        }

        // POST: Vueloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVuelo,NumeroVuelo,FechaVuelo,IdAvion,IdPiloto")] Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", vuelo.IdAvion);
            ViewData["IdPiloto"] = new SelectList(_context.Pilotos, "IdPiloto", "IdPiloto", vuelo.IdPiloto);
            return View(vuelo);
        }

        // GET: Vueloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vuelos == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", vuelo.IdAvion);
            ViewData["IdPiloto"] = new SelectList(_context.Pilotos, "IdPiloto", "IdPiloto", vuelo.IdPiloto);
            return View(vuelo);
        }

        // POST: Vueloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVuelo,NumeroVuelo,FechaVuelo,IdAvion,IdPiloto")] Vuelo vuelo)
        {
            if (id != vuelo.IdVuelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vuelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueloExists(vuelo.IdVuelo))
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
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", vuelo.IdAvion);
            ViewData["IdPiloto"] = new SelectList(_context.Pilotos, "IdPiloto", "IdPiloto", vuelo.IdPiloto);
            return View(vuelo);
        }

        // GET: Vueloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vuelos == null)
            {
                return NotFound();
            }

            var vuelo = await _context.Vuelos
                .Include(v => v.IdAvionNavigation)
                .Include(v => v.IdPilotoNavigation)
                .FirstOrDefaultAsync(m => m.IdVuelo == id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return View(vuelo);
        }

        // POST: Vueloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vuelos == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.Vuelos'  is null.");
            }
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo != null)
            {
                _context.Vuelos.Remove(vuelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueloExists(int id)
        {
          return (_context.Vuelos?.Any(e => e.IdVuelo == id)).GetValueOrDefault();
        }
    }
}
