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
    public class AvionesController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public AvionesController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: Aviones
        public async Task<IActionResult> Index()
        {
            var bDGAeropuertoContext = _context.Aviones.Include(a => a.IdModeloNavigation).Include(a => a.IdPropietarioNavigation).Include(a => a.IdTipoAvionNavigation);
            return View(await bDGAeropuertoContext.ToListAsync());
        }

        // GET: Aviones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aviones == null)
            {
                return NotFound();
            }

            var avione = await _context.Aviones
                .Include(a => a.IdModeloNavigation)
                .Include(a => a.IdPropietarioNavigation)
                .Include(a => a.IdTipoAvionNavigation)
                .FirstOrDefaultAsync(m => m.IdAvion == id);
            if (avione == null)
            {
                return NotFound();
            }

            return View(avione);
        }

        // GET: Aviones/Create
        public IActionResult Create()
        {
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo");
            ViewData["IdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario");
            ViewData["IdTipoAvion"] = new SelectList(_context.TipoAvions, "IdTipoAvion", "IdTipoAvion");
            return View();
        }

        // POST: Aviones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvion,SiglasAvion,IdTipoAvion,CapacidadPeso,IdModelo,IdPropietario")] Avione avione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", avione.IdModelo);
            ViewData["IdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", avione.IdPropietario);
            ViewData["IdTipoAvion"] = new SelectList(_context.TipoAvions, "IdTipoAvion", "IdTipoAvion", avione.IdTipoAvion);
            return View(avione);
        }

        // GET: Aviones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aviones == null)
            {
                return NotFound();
            }

            var avione = await _context.Aviones.FindAsync(id);
            if (avione == null)
            {
                return NotFound();
            }
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", avione.IdModelo);
            ViewData["IdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", avione.IdPropietario);
            ViewData["IdTipoAvion"] = new SelectList(_context.TipoAvions, "IdTipoAvion", "IdTipoAvion", avione.IdTipoAvion);
            return View(avione);
        }

        // POST: Aviones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvion,SiglasAvion,IdTipoAvion,CapacidadPeso,IdModelo,IdPropietario")] Avione avione)
        {
            if (id != avione.IdAvion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvioneExists(avione.IdAvion))
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
            ViewData["IdModelo"] = new SelectList(_context.Modelos, "IdModelo", "IdModelo", avione.IdModelo);
            ViewData["IdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", avione.IdPropietario);
            ViewData["IdTipoAvion"] = new SelectList(_context.TipoAvions, "IdTipoAvion", "IdTipoAvion", avione.IdTipoAvion);
            return View(avione);
        }

        // GET: Aviones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aviones == null)
            {
                return NotFound();
            }

            var avione = await _context.Aviones
                .Include(a => a.IdModeloNavigation)
                .Include(a => a.IdPropietarioNavigation)
                .Include(a => a.IdTipoAvionNavigation)
                .FirstOrDefaultAsync(m => m.IdAvion == id);
            if (avione == null)
            {
                return NotFound();
            }

            return View(avione);
        }

        // POST: Aviones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aviones == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.Aviones'  is null.");
            }
            var avione = await _context.Aviones.FindAsync(id);
            if (avione != null)
            {
                _context.Aviones.Remove(avione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvioneExists(int id)
        {
          return (_context.Aviones?.Any(e => e.IdAvion == id)).GetValueOrDefault();
        }
    }
}
