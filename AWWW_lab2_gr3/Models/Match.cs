namespace AWWW_lab2_gr3.Models
{
    public class Match
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public string Stadium {get; set;}
        public ICollection<MatchEvent> MatchEvents {get; set;}
        public ICollection<MatchPlayer> MatchPlayer {get; set;}
        public virtual Team HomeTeam {get; set;}
        public int HomeTeamId {get;set;}
        public virtual Team AwayTeam {get; set;}
        public int AwayTeamId {get; set;}
        public ICollection<Article> Articles {get; set;}
    }
}