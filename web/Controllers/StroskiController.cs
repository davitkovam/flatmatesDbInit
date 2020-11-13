using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class StroskiController : Controller
    {
        private readonly FlatmatesContext _context;

        public StroskiController(FlatmatesContext context)
        {
            _context = context;
        }

        // GET: Stroski
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stroski.ToListAsync());
        }

        // GET: Stroski/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stroski = await _context.Stroski
                .FirstOrDefaultAsync(m => m.strosekID == id);
            if (stroski == null)
            {
                return NotFound();
            }

            return View(stroski);
        }

        // GET: Stroski/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stroski/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("strosekID,month,householdID,amount,paid,description")] Stroski stroski)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stroski);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stroski);
        }

        // GET: Stroski/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stroski = await _context.Stroski.FindAsync(id);
            if (stroski == null)
            {
                return NotFound();
            }
            return View(stroski);
        }

        // POST: Stroski/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("strosekID,month,householdID,amount,paid,description")] Stroski stroski)
        {
            if (id != stroski.strosekID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stroski);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StroskiExists(stroski.strosekID))
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
            return View(stroski);
        }

        // GET: Stroski/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stroski = await _context.Stroski
                .FirstOrDefaultAsync(m => m.strosekID == id);
            if (stroski == null)
            {
                return NotFound();
            }

            return View(stroski);
        }

        // POST: Stroski/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stroski = await _context.Stroski.FindAsync(id);
            _context.Stroski.Remove(stroski);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StroskiExists(int id)
        {
            return _context.Stroski.Any(e => e.strosekID == id);
        }
    }
}
