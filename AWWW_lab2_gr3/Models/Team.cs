using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Datetime FoundingDate { get; set; }
        public list<Player> players { get; set; }
        public League league { get; set; }
        public int LeagueId { get; set; }
        public list<Match> Matches { get; set; }

    }
}