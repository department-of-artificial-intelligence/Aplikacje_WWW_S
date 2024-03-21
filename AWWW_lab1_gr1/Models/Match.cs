namespace AWWW_lab1_gr1.Models;


public class Match {
    public int Id { get; set;}

    public required DateTime Date { get; set; }

    public required string Stadium { get; set; }

    public required List<MatchPlayer> MatchPlayers { get; set; }

    public  List<MatchEvent> MatchEvents { get; set; }

    public List<Article> Articles { get; set; }
}
