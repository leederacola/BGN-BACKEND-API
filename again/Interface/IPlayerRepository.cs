using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;


namespace again.Interface
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Player CreatePlayer(Player player);
        Task<Player> EditPlayer(Player player);
        Task<int> DeletePlayer(int id);
        bool PlayerExist(int id);
    }
}
