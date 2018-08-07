using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace again.Models
{
    public class againContext : DbContext
    {
        public againContext (DbContextOptions<againContext> options)
            : base(options)
        {
        }

        public DbSet<again.Models.Game> Game { get; set; }
        public DbSet<again.Models.Player> Player { get; set; }
        public DbSet<again.Models.Library> Library { get; set; }
    }
}
