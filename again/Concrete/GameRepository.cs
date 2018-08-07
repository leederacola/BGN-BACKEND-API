using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Interface;
using again.Models;
using Microsoft.EntityFrameworkCore;

namespace again.Concrete
{
    public class GameRepository : IGameRepository
    {
        private readonly againContext _dbContext;

        public GameRepository(againContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _dbContext.Game.ToList();
        }

        public async Task<Game> GameDetail(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var game = await _dbContext.Game
                .FirstOrDefaultAsync(m => m.GameID == id);
            if (game == null)
            {
                return null;
            }
            return game;

        }

        public void CreateGame (Game game)
        {
            _dbContext.Game.Add(game);
            _dbContext.SaveChanges();
        }

        public void EditGame(Game game)
        {

        }

    }
}
