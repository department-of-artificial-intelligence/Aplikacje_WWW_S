using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Team
    {
        public int? HomeTeamId {get; set;}
        public int? AwayTeamId {get; set;}
        public string Name {get; set;} = null!; 
        public string Country {get; set;} = null!; 
        public string City {get; set;} = null!; 
        public DateTime FoundingDate {get; set;} 
        public ICollection<Match>? HomeMatches {get; set;}
        public ICollection<Match>? AwayMatches {get; set;}
    }
}