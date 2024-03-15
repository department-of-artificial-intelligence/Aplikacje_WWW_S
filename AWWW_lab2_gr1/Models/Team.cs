namespace AWWW_lab2_gr1.Models;
public class Team
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Country { get; set; }
  public string City { get; set; }
  public DateTime FoundingDate { get; set; }

  public ICollection<League> League { get; set; }
  public ICollection<MatchPlayer> MatchPlayers { get; set; }
  public ICollection<Match> Matches { get; set; }

}