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
    public class EstadiumsController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public EstadiumsController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: Estadiums
        public async Task<IActionResult> Index()
        {
            var bDGAeropuertoContext = _context.Estadia.Include(e => e.IdAvionNavigation).Include(e => e.IdHangarNavigation);
            return View(await bDGAeropuertoContext.ToListAsync());
        }

        // GET: Estadiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estadia == null)
            {
                return NotFound();
            }

            var estadium = await _context.Estadia
                .Include(e => e.IdAvionNavigation)
                .Include(e => e.IdHangarNavigation)
                .FirstOrDefaultAsync(m => m.IdEstadia == id);
            if (estadium == null)
            {
                return NotFound();
            }

            return View(estadium);
        }

        // GET: Estadiums/Create
        public IActionResult Create()
        {
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion");
            ViewData["IdHangar"] = new SelectList(_context.Hangars, "IdHangar", "IdHangar");
            return View();
        }

        // POST: Estadiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadia,FechaInicio,FechaFin,IdHangar,IdAvion")] Estadium estadium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", estadium.IdAvion);
            ViewData["IdHangar"] = new SelectList(_context.Hangars, "IdHangar", "IdHangar", estadium.IdHangar);
            return View(estadium);
        }

        // GET: Estadiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estadia == null)
            {
                return NotFound();
            }

            var estadium = await _context.Estadia.FindAsync(id);
            if (estadium == null)
            {
                return NotFound();
            }
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", estadium.IdAvion);
            ViewData["IdHangar"] = new SelectList(_context.Hangars, "IdHangar", "IdHangar", estadium.IdHangar);
            return View(estadium);
        }

        // POST: Estadiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadia,FechaInicio,FechaFin,IdHangar,IdAvion")] Estadium estadium)
        {
            if (id != estadium.IdEstadia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadiumExists(estadium.IdEstadia))
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
            ViewData["IdAvion"] = new SelectList(_context.Aviones, "IdAvion", "IdAvion", estadium.IdAvion);
            ViewData["IdHangar"] = new SelectList(_context.Hangars, "IdHangar", "IdHangar", estadium.IdHangar);
            return View(estadium);
        }

        // GET: Estadiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estadia == null)
            {
                return NotFound();
            }

            var estadium = await _context.Estadia
                .Include(e => e.IdAvionNavigation)
                .Include(e => e.IdHangarNavigation)
                .FirstOrDefaultAsync(m => m.IdEstadia == id);
            if (estadium == null)
            {
                return NotFound();
            }

            return View(estadium);
        }

        // POST: Estadiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estadia == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.Estadia'  is null.");
            }
            var estadium = await _context.Estadia.FindAsync(id);
            if (estadium != null)
            {
                _context.Estadia.Remove(estadium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadiumExists(int id)
        {
          return (_context.Estadia?.Any(e => e.IdEstadia == id)).GetValueOrDefault();
        }
    }
}
