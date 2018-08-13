using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using again.Models;
using again.Interface;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;

namespace again.Controllers
{
    [Route("api/players")]
    [EnableCors("LocalTest")]
    [ApiController]
    public class PlayerApiController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerApiController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        //GET: api/players
        [Route("")]
        [HttpGet]
        public Task<IEnumerable<Player>> GetAllPlayers()
        {
            var players = _playerRepository.GetAllPlayers();
            return players;
        }
    }
}