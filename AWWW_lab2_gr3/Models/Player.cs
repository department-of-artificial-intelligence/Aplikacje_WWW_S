using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
        public List<Position> Positions { get; set; }
        public Position position{ get; set; }
        public int PositionId { get; set; }
        public Team team{ get; set; }
        public int TeamId { get; set; }
    }
}