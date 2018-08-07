using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;

namespace again.Models
{
    public class Library
    {
        public int LibraryID { get; set; }
        // f-key
        public int PlayerID { get; set; }
        // f-key
        public int GameID { get; set; }

        public Player Player { get; set; }
        public Game Game { get; set; }
    }
}
