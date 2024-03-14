

namespace AWWW_lab1_gr1.Models;

public class Match
{
    public int Id{get ;set;}
    public DateTime Date{get;set;}
    public required string Stadium{get;set;}

    public required ICollection<Article> Articles{get;set;}

    public required ICollection<MatchEvent> MatchEvents{get;set;}

    public required ICollection<MatchPlayer> MatchPlayers{get;set;}

    public required Team HomeTeam{get;set;}

    public required Team AwayTeam{get;set;}

     public required int HomeTeamId{get;set;}

    public required int AwayTeamId{get;set;}
}