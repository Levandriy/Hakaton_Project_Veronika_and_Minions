using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test;
using Test.Data;

namespace Test.Controllers
{
    public class AccessesController : Controller
    {
        private readonly TestContext _context;

        public AccessesController(TestContext context)
        {
            _context = context;
        }

        // GET: Accesses
        public async Task<IActionResult> Index()
        {
              return _context.Access != null ? 
                          View(await _context.Access.ToListAsync()) :
                          Problem("Entity set 'TestContext.Access'  is null.");
        }

        // GET: Accesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Access == null)
            {
                return NotFound();
            }

            var access = await _context.Access
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access == null)
            {
                return NotFound();
            }

            return View(access);
        }

        // GET: Accesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Access access)
        {
            if (ModelState.IsValid)
            {
                _context.Add(access);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(access);
        }

        // GET: Accesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Access == null)
            {
                return NotFound();
            }

            var access = await _context.Access.FindAsync(id);
            if (access == null)
            {
                return NotFound();
            }
            return View(access);
        }

        // POST: Accesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Access access)
        {
            if (id != access.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(access);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessExists(access.Id))
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
            return View(access);
        }

        // GET: Accesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Access == null)
            {
                return NotFound();
            }

            var access = await _context.Access
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access == null)
            {
                return NotFound();
            }

            return View(access);
        }

        // POST: Accesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Access == null)
            {
                return Problem("Entity set 'TestContext.Access'  is null.");
            }
            var access = await _context.Access.FindAsync(id);
            if (access != null)
            {
                _context.Access.Remove(access);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessExists(int id)
        {
          return (_context.Access?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
