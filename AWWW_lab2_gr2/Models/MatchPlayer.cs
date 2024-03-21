using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchPlayer
    {
        public int Id {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}

        public virtual Match match {get; set;} = null!;
        public virtual ICollection<MatchEvent>? matchEvents {get;set;}
        public virtual Position position {get;set;} = null!;
        public virtual Player player {get;set;} = null!;
    }
}