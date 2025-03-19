using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Player>? Players { get; set; }
        public ICollection<MatchPlayer>? MatchPlayers { get; set; }
    }
}