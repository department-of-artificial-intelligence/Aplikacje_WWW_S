namespace AWWW_lab1_gr1.Models;
public class Match {
    public int Id { get; set;}

    public  DateTime Date { get; set; }

    public required string Stadium { get; set; }

    public required List<MatchPlayer> MatchPlayers { get; set; }

    public required List<MatchEvent> MatchEvents { get; set; }

    public required List<Article> Articles { get; set; }

    public  int HomeTeamId {get;set;}
    public  int AwayTeamId {get;set;}
    public required Team HomeTeam {get;set;}
    public required Team AwayTeam {get;set;}
}