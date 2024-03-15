public class MatchEvent {
    public int Id { get; set; }

    public required int Minute { get; set; }

    public required Match Match { get; set; }

    public MatchPlayer? MatchPlayer { get; set; }

    public required EventType EventType { get; set; }

}