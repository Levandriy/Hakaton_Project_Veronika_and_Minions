using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly TestContext _context;

        public CatalogsController(TestContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
              return _context.Catalogs != null ? 
                          View(await _context.Catalogs.ToListAsync()) :
                          Problem("Entity set 'TestContext.Catalogs'  is null.");
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalogs = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogs == null)
            {
                return NotFound();
            }

            return View(catalogs);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Catalogs catalogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogs);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalogs = await _context.Catalogs.FindAsync(id);
            if (catalogs == null)
            {
                return NotFound();
            }
            return View(catalogs);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Catalogs catalogs)
        {
            if (id != catalogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogsExists(catalogs.Id))
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
            return View(catalogs);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalogs == null)
            {
                return NotFound();
            }

            var catalogs = await _context.Catalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogs == null)
            {
                return NotFound();
            }

            return View(catalogs);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalogs == null)
            {
                return Problem("Entity set 'TestContext.Catalogs'  is null.");
            }
            var catalogs = await _context.Catalogs.FindAsync(id);
            if (catalogs != null)
            {
                _context.Catalogs.Remove(catalogs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogsExists(int id)
        {
          return (_context.Catalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
