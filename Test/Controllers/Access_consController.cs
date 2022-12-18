using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Test.Data;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Access_consController : ControllerBase
    {
        private readonly TestContext _context;

        public Access_consController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Access_cons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Access_cons>>> GetAccess_Cons()
        {
          if (_context.Access_Cons == null)
          {
              return NotFound();
          }
            return await _context.Access_Cons.ToListAsync();
        }

        // GET: api/Access_cons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Access_cons>> GetAccess_cons(int id)
        {
          if (_context.Access_Cons == null)
          {
              return NotFound();
          }
            var access_cons = await _context.Access_Cons.FindAsync(id);

            if (access_cons == null)
            {
                return NotFound();
            }

            return access_cons;
        }

        // PUT: api/Access_cons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccess_cons(int id, Access_cons access_cons)
        {
            if (id != access_cons.Id)
            {
                return BadRequest();
            }

            _context.Entry(access_cons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Access_consExists(id))
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

        // POST: api/Access_cons
        [HttpPost]
        public async Task<ActionResult<Access_cons>> PostAccess_cons(Access_cons access_cons)
        {
          if (_context.Access_Cons == null)
          {
              return Problem("Entity set 'TestContext.Access_Cons'  is null.");
          }
            _context.Access_Cons.Add(access_cons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccess_cons", new { id = access_cons.Id }, access_cons);
        }

        // DELETE: api/Access_cons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccess_cons(int id)
        {
            if (_context.Access_Cons == null)
            {
                return NotFound();
            }
            var access_cons = await _context.Access_Cons.FindAsync(id);
            if (access_cons == null)
            {
                return NotFound();
            }

            _context.Access_Cons.Remove(access_cons);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Access_consExists(int id)
        {
            return (_context.Access_Cons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
