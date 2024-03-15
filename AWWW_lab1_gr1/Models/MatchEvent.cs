namespace AWWW_lab1_gr1.Models;
public class MatchEvent
{
    public int Id { get; set; }
    public string EventType { get; set; }
    public virtual Match Match { get; set; }
}