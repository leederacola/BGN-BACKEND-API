using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using again.Models;

namespace again.Controllers
{
    public class LibraryController : Controller
    {
        private readonly againContext _context;

        public LibraryController(againContext context)
        {
            _context = context;
        }

        // GET: Library
        public async Task<IActionResult> Index()
        {
            var againContext = _context.Library.Include(l => l.Game).Include(l => l.Player);
            return View(await againContext.ToListAsync());
        }

        // GET: Library/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library
                .Include(l => l.Game)
                .Include(l => l.Player)
                .FirstOrDefaultAsync(m => m.LibraryID == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // GET: Library/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID");
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID");
            return View();
        }

        // POST: Library/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibraryID,PlayerID,GameID")] Library library)
        {
            if (ModelState.IsValid)
            {
                _context.Add(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", library.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", library.PlayerID);
            return View(library);
        }

        // GET: Library/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", library.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", library.PlayerID);
            return View(library);
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibraryID,PlayerID,GameID")] Library library)
        {
            if (id != library.LibraryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(library);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryExists(library.LibraryID))
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
            ViewData["GameID"] = new SelectList(_context.Game, "GameID", "GameID", library.GameID);
            ViewData["PlayerID"] = new SelectList(_context.Player, "PlayerID", "PlayerID", library.PlayerID);
            return View(library);
        }

        // GET: Library/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Library
                .Include(l => l.Game)
                .Include(l => l.Player)
                .FirstOrDefaultAsync(m => m.LibraryID == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // POST: Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var library = await _context.Library.FindAsync(id);
            _context.Library.Remove(library);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.LibraryID == id);
        }
    }
}
