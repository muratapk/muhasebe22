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
    public class ogretmenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ogretmenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ogretmen
        public async Task<IActionResult> Index()
        {
           
;            var applicationDbContext = _context.ogretmens.Include(o => o.okul);
            //include bizim tablodaki inner join denk
            return View( await applicationDbContext.ToListAsync());
        }

        // GET: ogretmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ogretmens == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.ogretmens
                .Include(o => o.okul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // GET: ogretmen/Create
        public IActionResult Create()
        {
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id");
            return View();
        }

        // POST: ogretmen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,adsoyad,tcno,sinif,okulId,Iban,unvan")] ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretmen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogretmen.okulId);
            return View(ogretmen);
        }

        // GET: ogretmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ogretmens == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.ogretmens.FindAsync(id);
            if (ogretmen == null)
            {
                return NotFound();
            }
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogretmen.okulId);
            return View(ogretmen);
        }

        // POST: ogretmen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,adsoyad,tcno,sinif,okulId,Iban,unvan")] ogretmen ogretmen)
        {
            if (id != ogretmen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretmen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ogretmenExists(ogretmen.Id))
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
            ViewData["okulId"] = new SelectList(_context.okuls, "Id", "Id", ogretmen.okulId);
            return View(ogretmen);
        }

        // GET: ogretmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ogretmens == null)
            {
                return NotFound();
            }

            var ogretmen = await _context.ogretmens
                .Include(o => o.okul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretmen == null)
            {
                return NotFound();
            }

            return View(ogretmen);
        }

        // POST: ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ogretmens == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ogretmens'  is null.");
            }
            var ogretmen = await _context.ogretmens.FindAsync(id);
            if (ogretmen != null)
            {
                _context.ogretmens.Remove(ogretmen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ogretmenExists(int id)
        {
          return (_context.ogretmens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
