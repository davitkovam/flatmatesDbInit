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
    public class ForumPostsController : Controller
    {
        private readonly FlatmatesContext _context;

        public ForumPostsController(FlatmatesContext context)
        {
            _context = context;
        }

        // GET: ForumPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forum_Posts.ToListAsync());
        }

        // GET: ForumPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Forum_Posts
                .FirstOrDefaultAsync(m => m.postID == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // GET: ForumPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ForumPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("postID,userID,householdID,content,timestamp")] ForumPost forumPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forumPost);
        }

        // GET: ForumPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Forum_Posts.FindAsync(id);
            if (forumPost == null)
            {
                return NotFound();
            }
            return View(forumPost);
        }

        // POST: ForumPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("postID,userID,householdID,content,timestamp")] ForumPost forumPost)
        {
            if (id != forumPost.postID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumPostExists(forumPost.postID))
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
            return View(forumPost);
        }

        // GET: ForumPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forumPost = await _context.Forum_Posts
                .FirstOrDefaultAsync(m => m.postID == id);
            if (forumPost == null)
            {
                return NotFound();
            }

            return View(forumPost);
        }

        // POST: ForumPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forumPost = await _context.Forum_Posts.FindAsync(id);
            _context.Forum_Posts.Remove(forumPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumPostExists(int id)
        {
            return _context.Forum_Posts.Any(e => e.postID == id);
        }
    }
}
