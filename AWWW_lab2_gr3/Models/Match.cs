namespace AWWW_lab2_gr3.Models;

public class Match {
    public string Id { get; set;}
    public DateTime date { get; set;}

    public int HomeTeamId { get; set;}
    //public virtual Match Match{ get; set;}
    public int AwayTeamId { get; set;}
    public virtual Match Match{ get; set;}
    public ICollection<MatchEvent> MatchEvents { get; set; }
    public ICollection<MatchPlayer> MatchPlayers { get; set; }
    public ICollection<Article> Articles { get; set; }

}