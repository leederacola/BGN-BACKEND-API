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
    [Route("api/games")]
    [ApiController]
    public class GamesApiController : ControllerBase
    {
        private readonly IGameRepository _gamesRepository;

        public GamesApiController(IGameRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        //GET: api/games
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Game>> GetAllGames()
        {
            var games = _gamesRepository.GetAllGames();
            return games;
        }

        //GET: api/Game/id
        [Route("{id:int}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _gamesRepository.GetGame(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}