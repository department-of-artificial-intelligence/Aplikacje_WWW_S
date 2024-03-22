namespace AWW_lab2_gr1.Models;

public class Team
{
  public int Id { get; set; }

  public string Name { get; set; }
  public string Country { get; set; }
  public string City { get; set; }
  public DateTime FoundingDate { get; set; }

  public League League { get; set; }

  public ICollection<Match> HomeMatches { get; set; }
  public ICollection<Match> AwayMatches { get; set; }
  public ICollection<Player> Players { get; set; }
}