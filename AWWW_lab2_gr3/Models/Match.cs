namespace AWWW_lab2_gr3.Models;

public class Match {
    public string Id { get; set;}
    public DateTime date { get; set;}

    public ICollection<Team> Team { get; set; }
    public ICollection<MatchEvent> MatchEvent { get; set; }
    public ICollection<MatchPlayer> MatchPlayer { get; set; }
    public ICollection<Article> Article { get; set; }

}