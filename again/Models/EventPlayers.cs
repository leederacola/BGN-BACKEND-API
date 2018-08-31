using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace again.Models
{
    public class EventPlayers
    {
        public int EventPlayersID;
        public int EventID;
        public int PlayerID;

        public Player Player { get; set; }
        public Event Event { get; set; }
    }
}
