using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public ICollection<MatchPlayer>? MatchPlayers { get; set; }
        public ICollection<Position> Positions { get; set; } = null!;
    }
}