using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Interface;
using again.Models;
using Microsoft.EntityFrameworkCore;

namespace again.Concrete
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly againContext _dbContext;

        public LibraryRepository(againContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Library>> GetAllLibraries()
        {
            /***
                SELECT Library.PlayerID, Player.Name, Library.GameID, Game.Title
                FROM Library
                JOIN Player ON Library.PlayerID = Player.PlayerID
                JOIN Game ON Library.GameID = Game.GameID;
             */
            var db = _dbContext.Library.Include(l => l.Game).Include(l => l.Player);
            return await db.ToListAsync();
        }

        public async Task<Library> GetLibraryById(int id)
        {
            var library = await _dbContext.Library
                .Include(l => l.Game)
                .Include(l => l.Player)
                .FirstOrDefaultAsync(m => m.LibraryID == id);

            return library;
        }

        public async Task<Library> CreateLibrary(Library library)
        {
            _dbContext.Library.Add(library);
            await _dbContext.SaveChangesAsync();
            return library;
        }

        public async Task<int> DeleteLibrary(int id)
        {
            var libraryToDelete = await _dbContext.Library.FindAsync(id);
            _dbContext.Library.Remove(libraryToDelete);
            _dbContext.SaveChanges();
            return id;
        }



    }
}


