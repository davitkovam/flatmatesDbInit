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
    public class ChoresController : Controller
    {
        private readonly FlatmatesContext _context;

        public ChoresController(FlatmatesContext context)
        {
            _context = context;
        }

        // GET: Chores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chores.ToListAsync());
        }

        // GET: Chores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores
                .FirstOrDefaultAsync(m => m.choreID == id);
            if (chore == null)
            {
                return NotFound();
            }

            return View(chore);
        }

        // GET: Chores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("choreID,userID,householdID,choredesc,duration,repetition,finished")] Chore chore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chore);
        }

        // GET: Chores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }
            return View(chore);
        }

        // POST: Chores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("choreID,userID,householdID,choredesc,duration,repetition,finished")] Chore chore)
        {
            if (id != chore.choreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoreExists(chore.choreID))
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
            return View(chore);
        }

        // GET: Chores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chore = await _context.Chores
                .FirstOrDefaultAsync(m => m.choreID == id);
            if (chore == null)
            {
                return NotFound();
            }

            return View(chore);
        }

        // POST: Chores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chore = await _context.Chores.FindAsync(id);
            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoreExists(int id)
        {
            return _context.Chores.Any(e => e.choreID == id);
        }
    }
}
