using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFamily.Data;
using MyFamily.Models;

namespace MyFamily.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliesController : ControllerBase
    {
        private readonly MyFamilyContext _context;

        public FamiliesController(MyFamilyContext context)
        {
            _context = context;
        }

        // GET: api/Families
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbFamily>>> GettbFamilys()
        {
          if (_context.tbFamilies == null)
          {
              return NotFound();
          }
            return await _context.tbFamilies.ToListAsync();
        }

        // GET: api/Families/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbFamily>> GettbFamily(Guid id)
        {
          if (_context.tbFamilies == null)
          {
              return NotFound();
          }
            var tbFamily = await _context.tbFamilies.FindAsync(id);

            if (tbFamily == null)
            {
                return NotFound();
            }

            return tbFamily;
        }

        // PUT: api/Families/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttbFamily(Guid id, tbFamily tbFamily)
        {
            if (id != tbFamily.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbFamily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbFamilyExists(id))
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

        // POST: api/Families
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbFamily>> PosttbFamily(tbFamily tbFamily)
        {
          if (_context.tbFamilies == null)
          {
              return Problem("Entity set 'FamilyContext.tbFamilys'  is null.");
          }
            _context.tbFamilies.Add(tbFamily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettbFamily", new { id = tbFamily.Id }, tbFamily);
        }

        // DELETE: api/Families/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetbFamily(Guid id)
        {
            if (_context.tbFamilies == null)
            {
                return NotFound();
            }
            var tbFamily = await _context.tbFamilies.FindAsync(id);
            if (tbFamily == null)
            {
                return NotFound();
            }

            _context.tbFamilies.Remove(tbFamily);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbFamilyExists(Guid id)
        {
            return (_context.tbFamilies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
