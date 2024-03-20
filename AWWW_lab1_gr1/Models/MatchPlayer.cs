public class MatchPlayer {
    public int Id {get; set;}

    public required DateTime StartTime {get; set;}

    public required DateTime EndTime {get; set;}

    public required Player Player {get; set;}

    public required Match Match {get; set;}

    public required Position Position {get; set;}
}