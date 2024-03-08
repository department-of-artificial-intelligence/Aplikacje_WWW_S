namespace AWWW_lab1_gr2.Models;
public class EventType{
    public int Id;
    public string ?Name;
    public ICollection<MatchEvent> MatchEvents {get; set;}=null!;
}