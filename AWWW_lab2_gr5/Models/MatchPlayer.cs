public class MatchPlayer
{
    public int Id {get; set;}
    public DateTime StartTime {get; set;}
    public DateTime EndTime {get; set;}
    public virtual Match Match {get; set;}
    public virtual List<MatchEvent> MatchEvents {get; set;}
}