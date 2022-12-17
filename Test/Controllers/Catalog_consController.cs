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
    public class Catalog_consController : Controller
    {
        private readonly TestContext _context;

        public Catalog_consController(TestContext context)
        {
            _context = context;
        }

        // GET: Catalog_cons
        public async Task<IActionResult> Index()
        {
              return _context.Catalog_cons != null ? 
                          View(await _context.Catalog_cons.ToListAsync()) :
                          Problem("Entity set 'TestContext.Catalog_cons'  is null.");
        }

        // GET: Catalog_cons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Catalog_cons == null)
            {
                return NotFound();
            }

            var catalog_cons = await _context.Catalog_cons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog_cons == null)
            {
                return NotFound();
            }

            return View(catalog_cons);
        }

        // GET: Catalog_cons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalog_cons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Catalog_id,Material_id")] Catalog_cons catalog_cons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog_cons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalog_cons);
        }

        // GET: Catalog_cons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Catalog_cons == null)
            {
                return NotFound();
            }

            var catalog_cons = await _context.Catalog_cons.FindAsync(id);
            if (catalog_cons == null)
            {
                return NotFound();
            }
            return View(catalog_cons);
        }

        // POST: Catalog_cons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Catalog_id,Material_id")] Catalog_cons catalog_cons)
        {
            if (id != catalog_cons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog_cons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Catalog_consExists(catalog_cons.Id))
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
            return View(catalog_cons);
        }

        // GET: Catalog_cons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Catalog_cons == null)
            {
                return NotFound();
            }

            var catalog_cons = await _context.Catalog_cons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog_cons == null)
            {
                return NotFound();
            }

            return View(catalog_cons);
        }

        // POST: Catalog_cons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Catalog_cons == null)
            {
                return Problem("Entity set 'TestContext.Catalog_cons'  is null.");
            }
            var catalog_cons = await _context.Catalog_cons.FindAsync(id);
            if (catalog_cons != null)
            {
                _context.Catalog_cons.Remove(catalog_cons);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Catalog_consExists(int id)
        {
          return (_context.Catalog_cons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
