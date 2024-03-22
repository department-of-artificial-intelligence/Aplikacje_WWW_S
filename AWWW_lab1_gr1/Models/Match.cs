public class Match{
    public int ID{get; set;}
    public required string Stadium{get;set;}
    public DateTime Date{get;set;}

    public required List<MatchPlayer> MatchPlayers { get; set; }

    public  List<MatchEvent>? MatchEvents { get; set; }

    public List<Article>? Articles { get; set; }
}