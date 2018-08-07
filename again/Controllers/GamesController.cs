using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using again.Interface;
using again.Models;

namespace again.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameRepository _gamesRepository;

        public GamesController(IGameRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _gamesRepository.GetAllGames());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _gamesRepository.GetGame(id);
               
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }


        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameID,Title,Description,MinPlayer,MaxPlayer,ImgPath,ThumbPath")] Game game)
        {
            if (ModelState.IsValid)
            {
                await _gamesRepository.AddGame(game);               
                return RedirectToAction(nameof(Index));
            }
            return View(game);
            /***TODO: this used to redirect to newely created game's detail view. It dont now!!!
             * Add game does not return newely created ID, it needs to!!!!!
             */
        }
        
        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _gamesRepository.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GameID,Title,Description,MinPlayer,MaxPlayer,ImgPath")] Game game)
        {
            if (id != game.GameID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _gamesRepository.EditGame(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_gamesRepository.GameExist(game.GameID))
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
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var game = await _gamesRepository.GetGame(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gamesRepository.DeleteGame(id);
            return RedirectToAction(nameof(Index));
        }











    }
}


//private readonly againContext _context;

//public GamesController(againContext context)
//{
//    _context = context;
//}

//// GET: Games
//public async Task<IActionResult> Index()
//{
//    return View(await _context.Game.ToListAsync());
//}

//// GET: Games/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var game = await _context.Game
//        .FirstOrDefaultAsync(m => m.GameID == id);
//    if (game == null)
//    {
//        return NotFound();
//    }

//    return View(game);
//}

//// GET: Games/Create
//public IActionResult Create()
//{
//    return View();
//}

//// POST: Games/Create
//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("GameID,Title,Description,MinPlayer,MaxPlayer,ImgPath,ThumbPath")] Game game)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(game);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    return View(game);
//}

//// GET: Games/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var game = await _context.Game.FindAsync(id);
//    if (game == null)
//    {
//        return NotFound();
//    }
//    return View(game);
//}

//// POST: Games/Edit/5
//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("GameID,Title,Description,MinPlayer,MaxPlayer,ImgPath")] Game game)
//{
//    if (id != game.GameID)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(game);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!GameExists(game.GameID))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }
//        return RedirectToAction(nameof(Index));
//    }
//    return View(game);
//}

//// GET: Games/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var game = await _context.Game
//        .FirstOrDefaultAsync(m => m.GameID == id);
//    if (game == null)
//    {
//        return NotFound();
//    }

//    return View(game);
//}

//// POST: Games/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var game = await _context.Game.FindAsync(id);
//    _context.Game.Remove(game);
//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}