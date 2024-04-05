using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class League
    {
        public int LeagueId {get; set;}
        public string Name {get; set;} = null!; 
        public string Country {get; set;} = null!; 
        public int Level {get; set;}
        public ICollection<Team>? Teams {get; set;}
        

    }
}