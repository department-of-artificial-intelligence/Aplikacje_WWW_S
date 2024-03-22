namespace AWW_lab2_gr1.Models;

public class Match
{
  public int Id { get; set; }
  public DateTime Date { get; set; }
  public string Stadium { get; set; }

  public ICollection<Article> Articles { get; set; }

  public int HomeTeamId { get; set; }
  public int AwayTeamId { get; set; }

  public Team AwayTeam { get; set; }
  public Team HomeTeam { get; set; }
  public ICollection<MatchPlayer> MatchPlayers { get; set; }
  public ICollection<MatchEvent> MatchEvents { get; set; }
}