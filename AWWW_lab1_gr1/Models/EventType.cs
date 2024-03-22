using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class EventType{
        public int ID{get; set;}
        public required string Name{get;set;}
        public virtual ICollection<MatchEvent>? MatchEvents { get; set; }
    }
}