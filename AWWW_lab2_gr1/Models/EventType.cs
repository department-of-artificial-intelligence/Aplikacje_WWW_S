namespace AWWW_lab2_gr1.Models;
public class EventType
{
  public int Id { get; set; }
  public string Name { get; set; }

  public ICollection<MatchEvent> MatchEvents { get; set; }

}