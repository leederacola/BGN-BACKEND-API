using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using again.Models;

namespace again.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }


        // navagation property
        public ICollection<Game> Games { get; set; }


    }
}
