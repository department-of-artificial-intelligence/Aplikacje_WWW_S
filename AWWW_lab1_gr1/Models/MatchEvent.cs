namespace AWWW_lab1_gr1.Models;
public class MatchEvent
{
    public int Id { get; set; }
    public int Minute { get; set; }
    public Match Match { get; set; } = null!;
    public int EventTypeId { get; set; }
    public EventType EventType { get; set; } = null!;
 
}