using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr3.Models
{
    public class MatchPlayer
    {
        public int id { get; set; }
        public Datetime StartTime { get; set; }
        public Datetime EndTime { get; set; }

    public IOcollection<matchEvent> matchEvents { get; set; }

    public int MatchId { get; set; }
    public virtual Match match{ get; set; }

    public int PositionId { get; set; }
    public virtual Position position{ get; set; }

    public int PlayerId { get; set; }
    public MatchPlayer player{ get; set; }
    }
}