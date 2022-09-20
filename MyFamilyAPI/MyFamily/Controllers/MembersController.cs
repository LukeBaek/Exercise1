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
    public class MembersController : ControllerBase
    {
        private readonly MyFamilyContext _context;

        public MembersController(MyFamilyContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbMember>>> GettbMembers()
        {
          if (_context.tbMembers == null)
          {
              return NotFound();
          }
            return await _context.tbMembers.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbMember>> GettbMember(Guid id)
        {
          if (_context.tbMembers == null)
          {
              return NotFound();
          }
            var tbMember = await _context.tbMembers.FindAsync(id);

            if (tbMember == null)
            {
                return NotFound();
            }

            return tbMember;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttbMember(Guid id, tbMember tbMember)
        {
            if (id != tbMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbMemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbMember>> PosttbMember(tbMember tbMember)
        {
          if (_context.tbMembers == null)
          {
              return Problem("Entity set 'FamilyContext.tbMembers'  is null.");
          }
            _context.tbMembers.Add(tbMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettbMember", new { id = tbMember.Id }, tbMember);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetbMember(Guid id)
        {
            if (_context.tbMembers == null)
            {
                return NotFound();
            }
            var tbMember = await _context.tbMembers.FindAsync(id);
            if (tbMember == null)
            {
                return NotFound();
            }

            _context.tbMembers.Remove(tbMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbMemberExists(Guid id)
        {
            return (_context.tbMembers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
