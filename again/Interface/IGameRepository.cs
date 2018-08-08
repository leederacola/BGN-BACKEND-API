using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;

namespace again.Interface
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllGames();
        Task<Game> GetGame(int? id);
        Task<Game> AddGame(Game game);
        Task<Game> EditGame(Game game);
        Task<int> DeleteGame(int id);
        bool GameExist(int id);
    }
}
