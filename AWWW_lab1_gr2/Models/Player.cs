using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class Player
    {
        public int PlayerId {get; set;}
        public string FirstName {get; set;} = null!; 
        public string LastName {get; set;} = null!; 
        public string Country {get; set;} = null!; 
        public DateTime BirthDate {get; set;}
        public int? TeamId {get; set;}
        public Team? Team {get; set;} 
        public ICollection<Position>? Positions {get; set;}
    }
}