using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels2
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<MatchPlayer> MatchPlayers { get; set; } = new List<MatchPlayer>();
        public ICollection<Position> Positions { get; set; } = new List<Position>();
    }
}