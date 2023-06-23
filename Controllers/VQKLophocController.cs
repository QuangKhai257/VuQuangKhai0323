using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using VuQuangKhai0323.Models;

namespace VuQuangKhai0323.Controllers
{
    public class VQKLophocController : Controller
    {
        private readonly MvcMovieContext _context;

        public VQKLophocController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: VQKLophoc
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.VQKLophoc.Include(v => v.VQKSinhvien);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: VQKLophoc/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VQKLophoc == null)
            {
                return NotFound();
            }

            var vQKLophoc = await _context.VQKLophoc
                .Include(v => v.VQKSinhvien)
                .FirstOrDefaultAsync(m => m.VQKTenlop == id);
            if (vQKLophoc == null)
            {
                return NotFound();
            }

            return View(vQKLophoc);
        }

        // GET: VQKLophoc/Create
        public IActionResult Create()
        {
            ViewData["VQKMalop"] = new SelectList(_context.VQKSinhvien, "VQKMalop", "VQKMalop");
            return View();
        }

        // POST: VQKLophoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VQKTenlop,VQKMalop")] VQKLophoc vQKLophoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vQKLophoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VQKMalop"] = new SelectList(_context.VQKSinhvien, "VQKMalop", "VQKMalop", vQKLophoc.VQKMalop);
            return View(vQKLophoc);
        }

        // GET: VQKLophoc/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VQKLophoc == null)
            {
                return NotFound();
            }

            var vQKLophoc = await _context.VQKLophoc.FindAsync(id);
            if (vQKLophoc == null)
            {
                return NotFound();
            }
            ViewData["VQKMalop"] = new SelectList(_context.VQKSinhvien, "VQKMasinhvien", "VQKMasinhvien", vQKLophoc.VQKMalop);
            return View(vQKLophoc);
        }

        // POST: VQKLophoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VQKTenlop,VQKMalop")] VQKLophoc vQKLophoc)
        {
            if (id != vQKLophoc.VQKTenlop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vQKLophoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VQKLophocExists(vQKLophoc.VQKTenlop))
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
            ViewData["VQKMalop"] = new SelectList(_context.VQKSinhvien, "VQKMasinhvien", "VQKMasinhvien", vQKLophoc.VQKMalop);
            return View(vQKLophoc);
        }

        // GET: VQKLophoc/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VQKLophoc == null)
            {
                return NotFound();
            }

            var vQKLophoc = await _context.VQKLophoc
                .Include(v => v.VQKSinhvien)
                .FirstOrDefaultAsync(m => m.VQKTenlop == id);
            if (vQKLophoc == null)
            {
                return NotFound();
            }

            return View(vQKLophoc);
        }

        // POST: VQKLophoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VQKLophoc == null)
            {
                return Problem("Entity set 'MvcMovieContext.VQKLophoc'  is null.");
            }
            var vQKLophoc = await _context.VQKLophoc.FindAsync(id);
            if (vQKLophoc != null)
            {
                _context.VQKLophoc.Remove(vQKLophoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VQKLophocExists(string id)
        {
          return (_context.VQKLophoc?.Any(e => e.VQKTenlop == id)).GetValueOrDefault();
        }
    }
}
