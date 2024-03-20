public class EventType {
    public int Id { get; set; }

    public required string Name { get; set; }

    public List<MatchEvent>? MatchEvents { get; set; }
}