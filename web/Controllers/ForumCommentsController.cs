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
    public class ForumCommentsController : Controller
    {
        private readonly FlatmatesContext _context;

        public ForumCommentsController(FlatmatesContext context)
        {
            _context = context;
        }

        // GET: ForumComments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forum_Comments.ToListAsync());
        }

        // GET: ForumComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumComment = await _context.Forum_Comments
                .FirstOrDefaultAsync(m => m.commentID == id);
            if (forumComment == null)
            {
                return NotFound();
            }

            return View(forumComment);
        }

        // GET: ForumComments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("commentID,postID,userID,content,timestamp")] ForumComment forumComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumComment);
        }

        // GET: ForumComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumComment = await _context.Forum_Comments.FindAsync(id);
            if (forumComment == null)
            {
                return NotFound();
            }
            return View(forumComment);
        }

        // POST: ForumComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("commentID,postID,userID,content,timestamp")] ForumComment forumComment)
        {
            if (id != forumComment.commentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumCommentExists(forumComment.commentID))
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
            return View(forumComment);
        }

        // GET: ForumComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumComment = await _context.Forum_Comments
                .FirstOrDefaultAsync(m => m.commentID == id);
            if (forumComment == null)
            {
                return NotFound();
            }

            return View(forumComment);
        }

        // POST: ForumComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumComment = await _context.Forum_Comments.FindAsync(id);
            _context.Forum_Comments.Remove(forumComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumCommentExists(int id)
        {
            return _context.Forum_Comments.Any(e => e.commentID == id);
        }
    }
}
