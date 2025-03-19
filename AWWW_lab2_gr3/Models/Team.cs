using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class Team{
        public int Id{get;set;}
        public string Name{get;set;}
        public string Country{get;set;}
        public string City{get;set;}
        public DateTime FoundingDate{get;set;}
        public int LeagueId { get; set; }
        public League League { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<MatchTeam> MatchTeams { get; set; }
    }
}