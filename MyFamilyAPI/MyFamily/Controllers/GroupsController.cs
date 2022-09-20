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
    public class GroupsController : ControllerBase
    {
        private readonly MyFamilyContext _context;

        public GroupsController(MyFamilyContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbGroup>>> GettbGroups()
        {
          if (_context.tbGroups == null)
          {
              return NotFound();
          }
            return await _context.tbGroups.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbGroup>> GettbGroup(Guid id)
        {
          if (_context.tbGroups == null)
          {
              return NotFound();
          }
            var tbGroup = await _context.tbGroups.FindAsync(id);

            if (tbGroup == null)
            {
                return NotFound();
            }

            return tbGroup;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttbGroup(Guid id, tbGroup tbGroup)
        {
            if (id != tbGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbGroupExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbGroup>> PosttbGroup(tbGroup tbGroup)
        {
          if (_context.tbGroups == null)
          {
              return Problem("Entity set 'FamilyContext.tbGroups'  is null.");
          }
            _context.tbGroups.Add(tbGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettbGroup", new { id = tbGroup.Id }, tbGroup);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetbGroup(Guid id)
        {
            if (_context.tbGroups == null)
            {
                return NotFound();
            }
            var tbGroup = await _context.tbGroups.FindAsync(id);
            if (tbGroup == null)
            {
                return NotFound();
            }

            _context.tbGroups.Remove(tbGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbGroupExists(Guid id)
        {
            return (_context.tbGroups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
