namespace AWWW_lab2_gr1.Models;
public class Player
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string Country { get; set; }
  public DateTime BirthDate { get; set; }

  public Team Team { get; set; }
  public ICollection<Position> Position { get; set; }
  public ICollection<MatchPlayer> MatchPlayers { get; set; }
}