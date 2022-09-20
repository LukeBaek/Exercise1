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
    public class AddressesController : ControllerBase
    {
        private readonly MyFamilyContext _context;

        public AddressesController(MyFamilyContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbAddress>>> GettbAddresss()
        {
          if (_context.tbAddresss == null)
          {
              return NotFound();
          }
            return await _context.tbAddresss.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbAddress>> GettbAddress(Guid id)
        {
          if (_context.tbAddresss == null)
          {
              return NotFound();
          }
            var tbAddress = await _context.tbAddresss.FindAsync(id);

            if (tbAddress == null)
            {
                return NotFound();
            }

            return tbAddress;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttbAddress(Guid id, tbAddress tbAddress)
        {
            if (id != tbAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbAddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbAddress>> PosttbAddress(tbAddress tbAddress)
        {
          if (_context.tbAddresss == null)
          {
              return Problem("Entity set 'FamilyContext.tbAddresss'  is null.");
          }
            _context.tbAddresss.Add(tbAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettbAddress", new { id = tbAddress.Id }, tbAddress);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetbAddress(Guid id)
        {
            if (_context.tbAddresss == null)
            {
                return NotFound();
            }
            var tbAddress = await _context.tbAddresss.FindAsync(id);
            if (tbAddress == null)
            {
                return NotFound();
            }

            _context.tbAddresss.Remove(tbAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbAddressExists(Guid id)
        {
            return (_context.tbAddresss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
