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
        public DateTime FoundingDate { get; set; }
        public List<Player> players { get; set; }
        public League league { get; set; }
        public int LeagueId { get; set; }
        public List<Match> Matches { get; set; }

    }
}