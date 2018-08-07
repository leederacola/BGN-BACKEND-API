using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;

namespace again.Interface
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAllGames();
        Task<Game> GameDetail(int? id);
        void CreateGame(Game game);
        void EditGame(Game game);
    }
}
