namespace AWWW_lab1_gr2.Models;
public class EventType{
    public int Id { get; set; }
    public string?Name { get; set; }
    public ICollection<MatchEvent> MatchEvents {get; set;}=null!;
}