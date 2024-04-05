using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class MatchEvent {
        public int Id { get; set; }
        public required int Minute { get; set; }
        public required int MatchID { get; set; }
        public required Match Match{get; set;}
        public int? MatchPlayerID{get; set;}
        public virtual MatchPlayer? MatchPlayer{get; set;}
        public int EventTypeID{get; set;}
        public required EventType EventType{get;set;}
    }
}