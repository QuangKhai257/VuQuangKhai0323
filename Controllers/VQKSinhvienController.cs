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
    public class VQKSinhvienController : Controller
    {
        private readonly MvcMovieContext _context;

        public VQKSinhvienController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: VQKSinhvien
        public async Task<IActionResult> Index()
        {
              return _context.VQKSinhvien != null ? 
                          View(await _context.VQKSinhvien.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.VQKSinhvien'  is null.");
        }

        // GET: VQKSinhvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VQKSinhvien == null)
            {
                return NotFound();
            }

            var vQKSinhvien = await _context.VQKSinhvien
                .FirstOrDefaultAsync(m => m.VQKMasinhvien == id);
            if (vQKSinhvien == null)
            {
                return NotFound();
            }

            return View(vQKSinhvien);
        }

        // GET: VQKSinhvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VQKSinhvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VQKMasinhvien,VQKHoten,VQKMalop")] VQKSinhvien vQKSinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vQKSinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vQKSinhvien);
        }

        // GET: VQKSinhvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VQKSinhvien == null)
            {
                return NotFound();
            }

            var vQKSinhvien = await _context.VQKSinhvien.FindAsync(id);
            if (vQKSinhvien == null)
            {
                return NotFound();
            }
            return View(vQKSinhvien);
        }

        // POST: VQKSinhvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VQKMasinhvien,VQKHoten,VQKMalop")] VQKSinhvien vQKSinhvien)
        {
            if (id != vQKSinhvien.VQKMasinhvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vQKSinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VQKSinhvienExists(vQKSinhvien.VQKMasinhvien))
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
            return View(vQKSinhvien);
        }

        // GET: VQKSinhvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VQKSinhvien == null)
            {
                return NotFound();
            }

            var vQKSinhvien = await _context.VQKSinhvien
                .FirstOrDefaultAsync(m => m.VQKMasinhvien == id);
            if (vQKSinhvien == null)
            {
                return NotFound();
            }

            return View(vQKSinhvien);
        }

        // POST: VQKSinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VQKSinhvien == null)
            {
                return Problem("Entity set 'MvcMovieContext.VQKSinhvien'  is null.");
            }
            var vQKSinhvien = await _context.VQKSinhvien.FindAsync(id);
            if (vQKSinhvien != null)
            {
                _context.VQKSinhvien.Remove(vQKSinhvien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VQKSinhvienExists(string id)
        {
          return (_context.VQKSinhvien?.Any(e => e.VQKMasinhvien == id)).GetValueOrDefault();
        }
    }
}
