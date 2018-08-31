using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace again.Models
{
    public class EventGames
    {
        public int EventGamesID;
        public int EventID;
        public int GameID;

        public Game Game { get; set; }
        public Event Event { get; set; }
    }
}
