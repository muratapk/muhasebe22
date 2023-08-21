using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using muhasebe22.Data;
using muhasebe22.Models;

namespace muhasebe22.Controllers
{
    public class OgrencisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OgrencisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ogrencis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ogrencis.Include(o => o.okul);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ogrencis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ogrencis == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.ogrencis
                .Include(o => o.okul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // GET: Ogrencis/Create
        public IActionResult Create()
        {
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id");
            return View();
        }

        // POST: Ogrencis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,adsoyad,tcno,sinif,okulId,Iban,unvan")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogrenci.okulId);
            return View(ogrenci);
        }

        // GET: Ogrencis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ogrencis == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.ogrencis.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogrenci.okulId);
            return View(ogrenci);
        }

        // POST: Ogrencis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,adsoyad,tcno,sinif,okulId,Iban,unvan")] Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciExists(ogrenci.Id))
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
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogrenci.okulId);
            return View(ogrenci);
        }

        // GET: Ogrencis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ogrencis == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.ogrencis
                .Include(o => o.okul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // POST: Ogrencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ogrencis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ogrencis'  is null.");
            }
            var ogrenci = await _context.ogrencis.FindAsync(id);
            if (ogrenci != null)
            {
                _context.ogrencis.Remove(ogrenci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciExists(int id)
        {
          return (_context.ogrencis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
