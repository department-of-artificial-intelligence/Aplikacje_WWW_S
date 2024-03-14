using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int PlayerId {  get; set; }
        public virtual Player Player {  get; set; }

        public int PositionId {  get; set; }
        public virtual Position Position { get; set; }

        public virtual ICollection<MatchEvent> MatchEvents { get; set; }


    }
}