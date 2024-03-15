namespace AWWW_lab2_gr1.Models;
public class Position
{
  public int Id { get; set; }
  public string Name { get; set; }

  public ICollection<Player> Player { get; set; }
  public ICollection<MatchPlayer> MatchPlayers { get; set; }
}