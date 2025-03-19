using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MatchPlayer> matchPlayers { get; set; }
        public ICollection<Player> players{ get; set; }
    }
}