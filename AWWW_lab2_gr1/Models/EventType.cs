namespace AWW_lab2_gr1.Models;

public class EventType
{
  public int ID { get; set; }
  public string Name { get; set; }

  public ICollection<MatchEvent> MatchEvents { get; set; }
}