using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Player
    {
        public int Id {get; set;}
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public string Country {get; set;} = null!;
        public DateTime BirthDate {get;set;}

        public virtual Team team {get; set;} = null!;
        public virtual ICollection<Position> position {get;set;} = null!;
        public virtual ICollection<MatchPlayer>? matchPlayers {get;set;}
 
    }
}