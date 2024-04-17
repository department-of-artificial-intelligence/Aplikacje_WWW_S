public class Match
{
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public string? Stadium {get; set;}
    public virtual IList<Article>? Articles {get; set;}
    public virtual IList<MatchEvent> MatchEvents {get; set;} = null!;
    public virtual IList<MatchPlayer> MatchPlayers {get; set;} = null!;
    public Team HomeTeam {get; set;} = null!;
    public int HomeTeamId {get; set;}
}