using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab1_gr2.Models
{
    public class MatchPlayer
    {
        public int Id {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}
        public virtual ICollection<MatchEvent>? MatchEvents {get;set;}
        public virtual Match Match {get;set;} = null!;
        public virtual Position Position {get;set;} = null!;
        public virtual Player Player {get;set;} = null!;
    }
}