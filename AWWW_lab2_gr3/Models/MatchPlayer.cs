namespace AWWW_lab2_gr3.Models {
    public class MatchPlayer {
        public int Id {get; set;}
        public DateTime StartTime {get;set;}
        public DateTime EndTime {get;set;}
        

        public int PlayerId {get;set;}
        public int PositionId {get;set;}
        public int MatchId {get;set;}
        public ICollection<MatchEvent> MatchEvents {get;set;}
    }
}