using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace again.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public DateTime DateTime { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; }

        // navagation property
        public ICollection<Game> EventGames { get; set; }
        public ICollection<Player> EventPlayers { get; set; }
    }
}
