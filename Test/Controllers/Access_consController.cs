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
    public class Access_consController : Controller
    {
        private readonly TestContext _context;

        public Access_consController(TestContext context)
        {
            _context = context;
        }

        // GET: Access_cons
        public async Task<IActionResult> Index()
        {
              return _context.Access_cons != null ? 
                          View(await _context.Access_cons.ToListAsync()) :
                          Problem("Entity set 'TestContext.Access_cons'  is null.");
        }

        // GET: Access_cons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Access_cons == null)
            {
                return NotFound();
            }

            var access_cons = await _context.Access_cons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access_cons == null)
            {
                return NotFound();
            }

            return View(access_cons);
        }

        // GET: Access_cons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Access_cons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Access_id,Material_id,Department_id")] Access_cons access_cons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(access_cons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(access_cons);
        }

        // GET: Access_cons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Access_cons == null)
            {
                return NotFound();
            }

            var access_cons = await _context.Access_cons.FindAsync(id);
            if (access_cons == null)
            {
                return NotFound();
            }
            return View(access_cons);
        }

        // POST: Access_cons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Access_id,Material_id,Department_id")] Access_cons access_cons)
        {
            if (id != access_cons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(access_cons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Access_consExists(access_cons.Id))
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
            return View(access_cons);
        }

        // GET: Access_cons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Access_cons == null)
            {
                return NotFound();
            }

            var access_cons = await _context.Access_cons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (access_cons == null)
            {
                return NotFound();
            }

            return View(access_cons);
        }

        // POST: Access_cons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Access_cons == null)
            {
                return Problem("Entity set 'TestContext.Access_cons'  is null.");
            }
            var access_cons = await _context.Access_cons.FindAsync(id);
            if (access_cons != null)
            {
                _context.Access_cons.Remove(access_cons);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Access_consExists(int id)
        {
          return (_context.Access_cons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
