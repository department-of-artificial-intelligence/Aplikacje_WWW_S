public class MatchPlayer
{
    public int Id {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}
    public virtual Match Match {get; set;}
    public virtual IList<MatchEvent> MatchEvents {get; set;}
    public virtual Position Position {get; set;}
}