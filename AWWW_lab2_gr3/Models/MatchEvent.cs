namespace AWWW_lab2_gr3.Models {
    public class MatchEvent {
        public int Id {get; set;}
        public string Minute {get;set;}

        public int MatchId {get;set;}
        public int MatchPlayerId {get;set;}

        public int EventTypeId {get;set;}
        
    }
}