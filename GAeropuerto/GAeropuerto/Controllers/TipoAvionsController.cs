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
    public class TipoAvionsController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public TipoAvionsController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: TipoAvions
        public async Task<IActionResult> Index()
        {
              return _context.TipoAvions != null ? 
                          View(await _context.TipoAvions.ToListAsync()) :
                          Problem("Entity set 'BDGAeropuertoContext.TipoAvions'  is null.");
        }

        // GET: TipoAvions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoAvions == null)
            {
                return NotFound();
            }

            var tipoAvion = await _context.TipoAvions
                .FirstOrDefaultAsync(m => m.IdTipoAvion == id);
            if (tipoAvion == null)
            {
                return NotFound();
            }

            return View(tipoAvion);
        }

        // GET: TipoAvions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAvions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoAvion,TipoAvion1")] TipoAvion tipoAvion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAvion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAvion);
        }

        // GET: TipoAvions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoAvions == null)
            {
                return NotFound();
            }

            var tipoAvion = await _context.TipoAvions.FindAsync(id);
            if (tipoAvion == null)
            {
                return NotFound();
            }
            return View(tipoAvion);
        }

        // POST: TipoAvions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoAvion,TipoAvion1")] TipoAvion tipoAvion)
        {
            if (id != tipoAvion.IdTipoAvion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAvion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAvionExists(tipoAvion.IdTipoAvion))
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
            return View(tipoAvion);
        }

        // GET: TipoAvions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoAvions == null)
            {
                return NotFound();
            }

            var tipoAvion = await _context.TipoAvions
                .FirstOrDefaultAsync(m => m.IdTipoAvion == id);
            if (tipoAvion == null)
            {
                return NotFound();
            }

            return View(tipoAvion);
        }

        // POST: TipoAvions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoAvions == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.TipoAvions'  is null.");
            }
            var tipoAvion = await _context.TipoAvions.FindAsync(id);
            if (tipoAvion != null)
            {
                _context.TipoAvions.Remove(tipoAvion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAvionExists(int id)
        {
          return (_context.TipoAvions?.Any(e => e.IdTipoAvion == id)).GetValueOrDefault();
        }
    }
}
