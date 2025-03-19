namespace AWWW_lab2_gr3.Models;

public class Match
{
    public int Id {get; set;}
    public DateTime Date {get; set;}
    public string Stadium {get; set;}

    public List<Article> Articles {get; set;}

    public int HomeTeamId {get; set}
    public int AwayTeamId {get; set;}
    public Team HomeTeam {get; set;}
    public Team AwayTeam {get; set;}

    public List<MatchPlayer> MatchPlayers {get; set;}

    public List<MatchEvent> MatchEvents {get; set;}
}