public class MatchEvent
{
    public int Id {get; set;}
    public int Minute {get; set;}
    public virtual Match Match {get; set;} = null!;
    public virtual MatchPlayer? MatchPlayer {get; set;}
    public virtual EventType EventType {get; set;} = null!;
}