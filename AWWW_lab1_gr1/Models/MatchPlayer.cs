using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class MatchPlayer{
        public int Id {get;set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}
        public int MatchID {get;set;}
        public virtual Match Match {get;set;}
        public virtual ICollection<MatchEvent> MatchEvents {get;}
        public int PlayerID {get;set;}
        public virtual Player Player {get;set;}
        public int PositionId {get;set;}
        public virtual Position Position {get;set;}
    }
}   