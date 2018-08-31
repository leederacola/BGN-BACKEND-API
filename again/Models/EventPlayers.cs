using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace again.Models
{
    public class EventPlayers
    {
        public int EventPlayersID { get; set; }
        public int EventID { get; set; }
        public int PlayerID { get; set; }

        public Player Player { get; set; }
        public Event Event { get; set; }
    }
}
