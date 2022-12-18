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
    public class CatalogsController : ControllerBase
    {
        private readonly TestContext _context;

        public CatalogsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Catalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogs>>> GetCatalogs()
        {
          if (_context.Catalogs == null)
          {
              return NotFound();
          }
            return await _context.Catalogs.ToListAsync();
        }

        // GET: api/Catalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogs>> GetCatalogs(int id)
        {
          if (_context.Catalogs == null)
          {
              return NotFound();
          }
            var catalogs = await _context.Catalogs.FindAsync(id);

            if (catalogs == null)
            {
                return NotFound();
            }

            return catalogs;
        }

        // PUT: api/Catalogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogs(int id, Catalogs catalogs)
        {
            if (id != catalogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogsExists(id))
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

        // POST: api/Catalogs
        [HttpPost]
        public async Task<ActionResult<Catalogs>> PostCatalogs(Catalogs catalogs)
        {
          if (_context.Catalogs == null)
          {
              return Problem("Entity set 'TestContext.Catalogs'  is null.");
          }
            _context.Catalogs.Add(catalogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogs", new { id = catalogs.Id }, catalogs);
        }

        // DELETE: api/Catalogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogs(int id)
        {
            if (_context.Catalogs == null)
            {
                return NotFound();
            }
            var catalogs = await _context.Catalogs.FindAsync(id);
            if (catalogs == null)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catalogs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogsExists(int id)
        {
            return (_context.Catalogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
