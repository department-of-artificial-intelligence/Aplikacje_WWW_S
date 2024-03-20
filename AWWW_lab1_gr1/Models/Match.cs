public class Match {
    public int Id { get; set;}

    public required DateTime Date { get; set; }

    public required string Stadium { get; set; }

    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }

    public required virtual Team HomeTeam { get; set; }
    public required virtual Team AwayTeam { get; set; }

    public required List<MatchPlayer> MatchPlayers { get; set; }

    public  List<MatchEvent>? MatchEvents { get; set; }

    public List<Article>? Articles { get; set; }
}