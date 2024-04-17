public class EventType
{
    public int Id {get; set;}
    public string Name {get; set;}
    public virtual IList<MatchEvent> MatchEvents {get; set;}
}