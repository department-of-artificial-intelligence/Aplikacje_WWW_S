namespace AWWW_lab1_gr1.Models;


public class Match {
    public int Id { get; set;}

    public DateTime Date { get; set; }

    public string Stadium { get; set; }

    public List<MatchPlayer> MatchPlayers { get; set; }

    public  List<MatchEvent> MatchEvents { get; set; }

    public List<Article> Articles { get; set; }
    public required virtual Team HomeTeam { get; set; }
    public required virtual Team AwayTeam { get; set; }
}
