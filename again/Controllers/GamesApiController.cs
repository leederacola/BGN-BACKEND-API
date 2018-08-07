using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using again.Models;
using again.Interface;

namespace again.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesApiController : ControllerBase
    {
        private readonly IGameRepository _gamesRepository;

        public GamesApiController(IGameRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        // GET: api/GamesApi
        [HttpGet]
        public IEnumerable<Game> GetGame()
        {
            return _gamesRepository.GetAllGames();
        }

        //// GET: api/GamesApi/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGame([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var game = await _context.Game.FindAsync(id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(game);
        //}

        //// PUT: api/GamesApi/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGame([FromRoute] int id, [FromBody] Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != game.GameID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/GamesApi
        //[HttpPost]
        //public async Task<IActionResult> PostGame([FromBody] Game game)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Game.Add(game);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = game.GameID }, game);
        //}

        //// DELETE: api/GamesApi/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGame([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var game = await _context.Game.FindAsync(id);
        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Game.Remove(game);
        //    await _context.SaveChangesAsync();

        //    return Ok(game);
        //}

        //private bool GameExists(int id)
        //{
        //    return _context.Game.Any(e => e.GameID == id);
        //}
    }
}