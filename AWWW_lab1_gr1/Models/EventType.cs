public class EventType{
    public int ID{get; set;}
    public required string Name{get;set;}
    public List<MatchEvent>? MatchEvents { get; set; }
}