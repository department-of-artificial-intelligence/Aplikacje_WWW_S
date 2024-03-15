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

        public Team team {get; set;} = null!;
        public List<Position> position = new List<Position>(); //= null!
        //do zrobienia
        public List<MatchPlayer> matchPlayers = new List<MatchPlayer>();
 
    }
}