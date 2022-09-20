using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFamily.Data;
using MyFamily.Models;

namespace MyFamily.Controllers
{
    public class tbFamiliesController : Controller
    {
        private readonly MyFamilyContext _context;

        public tbFamiliesController(MyFamilyContext context)
        {
            _context = context;
        }

        // GET: tbFamilies
        [HttpGet]
        public async Task<IActionResult> Index()
        {
              return _context.tbFamily != null ? 
                          View(await _context.tbFamily.ToListAsync()) :
                          Problem("Entity set 'MyFamilyContext.tbFamily'  is null.");
        }

        // GET: tbFamilies/Details/5
c
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.tbFamily == null)
            {
                return NotFound();
            }

            var tbFamily = await _context.tbFamily
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbFamily == null)
            {
                return NotFound();
            }

            return View(tbFamily);
        }

        // GET: tbFamilies/Create
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        // POST: tbFamilies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MemberId,GroupId,MainAddressId")] tbFamily tbFamily)
        {
            if (ModelState.IsValid)
            {
                tbFamily.Id = Guid.NewGuid();
                _context.Add(tbFamily);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbFamily);
        }

        // GET: tbFamilies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.tbFamily == null)
            {
                return NotFound();
            }

            var tbFamily = await _context.tbFamily.FindAsync(id);
            if (tbFamily == null)
            {
                return NotFound();
            }
            return View(tbFamily);
        }

        // POST: tbFamilies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MemberId,GroupId,MainAddressId")] tbFamily tbFamily)
        {
            if (id != tbFamily.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbFamily);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbFamilyExists(tbFamily.Id))
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
            return View(tbFamily);
        }

        // GET: tbFamilies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.tbFamily == null)
            {
                return NotFound();
            }

            var tbFamily = await _context.tbFamily
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbFamily == null)
            {
                return NotFound();
            }

            return View(tbFamily);
        }

        // POST: tbFamilies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.tbFamily == null)
            {
                return Problem("Entity set 'MyFamilyContext.tbFamily'  is null.");
            }
            var tbFamily = await _context.tbFamily.FindAsync(id);
            if (tbFamily != null)
            {
                _context.tbFamily.Remove(tbFamily);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbFamilyExists(Guid id)
        {
          return (_context.tbFamily?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
