using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace again.Models
{
    public class EventGames
    {
        public int EventGamesID { get; set; }
        public int EventID { get; set; }
        public int GameID { get; set; }

        // navigation property
        public Game Game { get; set; }
        public Event Event { get; set; }
    }
}
