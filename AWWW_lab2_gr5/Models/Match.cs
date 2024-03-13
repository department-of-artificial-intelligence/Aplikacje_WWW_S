public class Match
{
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public string? Stadium {get; set;}
    public virtual List<Article>? Articles {get; set;}
    public virtual List<MatchEvent> MatchEvents {get; set;} = null!;
    public virtual List<MatchPlayer> MatchPlayers {get; set;} = null!;
    public Team HomeTeam {get; set;} = null!;
    public int HomeTeamId {get; set;}
}