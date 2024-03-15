using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Team
    {
        public int Id{get;set;}
        public string Name{get;set;} = null!;
        public string? Country{get;set;}
        public string? City{get;set;}
        public DateTime FoundingDate{get;set;}
        public League League{get;set;} = null!;
        public IList<Match>? HomeMatches{get;set;}
        public IList<Match>? AwayMatches{get;set;}
    }
}