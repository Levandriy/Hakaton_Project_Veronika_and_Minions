using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Catalog_consController : ControllerBase
    {
        private readonly TestContext _context;

        public Catalog_consController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Catalog_cons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog_cons>>> GetCatalog_Cons()
        {
          if (_context.Catalogs_Cons == null)
          {
              return NotFound();
          }
            return await _context.Catalogs_Cons.ToListAsync();
        }

        // GET: api/Catalog_cons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog_cons>> GetCatalog_cons(int id)
        {
          if (_context.Catalogs_Cons == null)
          {
              return NotFound();
          }
            var catalog_cons = await _context.Catalogs_Cons.FindAsync(id);

            if (catalog_cons == null)
            {
                return NotFound();
            }

            return catalog_cons;
        }

        // PUT: api/Catalog_cons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalog_cons(int id, Catalog_cons catalog_cons)
        {
            if (id != catalog_cons.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalog_cons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Catalog_consExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Catalog_cons
        [HttpPost]
        public async Task<ActionResult<Catalog_cons>> PostCatalog_cons(Catalog_cons catalog_cons)
        {
          if (_context.Catalogs_Cons == null)
          {
              return Problem("Entity set 'TestContext.Catalog_Cons'  is null.");
          }
            _context.Catalogs_Cons.Add(catalog_cons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog_cons", new { id = catalog_cons.Id }, catalog_cons);
        }

        // DELETE: api/Catalog_cons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog_cons(int id)
        {
            if (_context.Catalogs_Cons == null)
            {
                return NotFound();
            }
            var catalog_cons = await _context.Catalogs_Cons.FindAsync(id);
            if (catalog_cons == null)
            {
                return NotFound();
            }

            _context.Catalogs_Cons.Remove(catalog_cons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Catalog_consExists(int id)
        {
            return (_context.Catalogs_Cons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
