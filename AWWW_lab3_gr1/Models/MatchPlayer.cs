namespace AWWW_lab3_gr1.Models;

public class MatchPlayer
{
  public int Id { get; set; }
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }

  public Position Position { get; set; }

  public Player Player { get; set; }

  public Match Match { get; set; }
  public ICollection<MatchEvent> MatchEvents { get; set; }
}