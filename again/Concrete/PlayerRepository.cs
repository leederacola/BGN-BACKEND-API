using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;
using again.Interface;
using Microsoft.EntityFrameworkCore;

namespace again.Concrete
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly againContext _dbContext;

        public PlayerRepository(againContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _dbContext.Player.ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            var player = await _dbContext.Player.FirstOrDefaultAsync(g => g.PlayerID == id);
            return player;
        }

        public async Task<Player> GetPlayerGamesById(int id)
        {
            var player = await  _dbContext.Player
                .Include(p => p.Games)
                .FirstOrDefaultAsync(g => g.PlayerID == id);
            return player;
        }




        public async Task<Player> CreatePlayer(Player player)
        {
             _dbContext.Player.Add(player);
             await _dbContext.SaveChangesAsync();
            return player;
        }

        public async Task<Player> EditPlayer(Player player)
        {
            _dbContext.Player.Update(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }

        public async Task<int> DeletePlayer(int id)
        {
            var player = await _dbContext.Player.FindAsync(id);
            _dbContext.Player.Remove(player);
            _dbContext.SaveChanges();
            return id;
        }

        //public async Task<IEnumerable<Game>> GetPlayerGames(int id)
        //{
            
        //}


        public bool PlayerExist(int id)
        {
            var b = _dbContext.Player.Any(e => e.PlayerID == id);
            return b;
        }



    }
}
