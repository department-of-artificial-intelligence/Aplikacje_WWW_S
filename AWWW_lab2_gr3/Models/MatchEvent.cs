namespace AWWW_lab2_gr3.Models;

public class MatchEvent{
    public int Id { get; set; }
    public int Minute { get; set; }

    public int EventTypeId { get; set; }
    public EventType EventType { get; set; }
}