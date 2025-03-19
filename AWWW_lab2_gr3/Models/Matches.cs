namespace AWWW_lab1_gr3.Models {
    public class Match {
        public int Id {get; set;}
        public DateTime Date {get;set;}
        public string Stadium {get;set;}

        public int HomeTeamId {get;set;}
        public int AwayTeamId {get;set;}

        public ICollection<Article> Articles {get;set;}
        public ICollection<MatchEvent> MatchEvents {get;set;}


    }
}