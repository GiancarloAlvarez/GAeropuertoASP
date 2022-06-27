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
    public class HangarsController : Controller
    {
        private readonly BDGAeropuertoContext _context;

        public HangarsController(BDGAeropuertoContext context)
        {
            _context = context;
        }

        // GET: Hangars
        public async Task<IActionResult> Index()
        {
              return _context.Hangars != null ? 
                          View(await _context.Hangars.ToListAsync()) :
                          Problem("Entity set 'BDGAeropuertoContext.Hangars'  is null.");
        }

        // GET: Hangars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hangars == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangars
                .FirstOrDefaultAsync(m => m.IdHangar == id);
            if (hangar == null)
            {
                return NotFound();
            }

            return View(hangar);
        }

        // GET: Hangars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hangars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHangar,CodigoHangar,Ubicacion,Capacidad")] Hangar hangar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangar);
        }

        // GET: Hangars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hangars == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangars.FindAsync(id);
            if (hangar == null)
            {
                return NotFound();
            }
            return View(hangar);
        }

        // POST: Hangars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHangar,CodigoHangar,Ubicacion,Capacidad")] Hangar hangar)
        {
            if (id != hangar.IdHangar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangarExists(hangar.IdHangar))
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
            return View(hangar);
        }

        // GET: Hangars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hangars == null)
            {
                return NotFound();
            }

            var hangar = await _context.Hangars
                .FirstOrDefaultAsync(m => m.IdHangar == id);
            if (hangar == null)
            {
                return NotFound();
            }

            return View(hangar);
        }

        // POST: Hangars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hangars == null)
            {
                return Problem("Entity set 'BDGAeropuertoContext.Hangars'  is null.");
            }
            var hangar = await _context.Hangars.FindAsync(id);
            if (hangar != null)
            {
                _context.Hangars.Remove(hangar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangarExists(int id)
        {
          return (_context.Hangars?.Any(e => e.IdHangar == id)).GetValueOrDefault();
        }
    }
}
