namespace AWWW_lab2_gr2.Models;
using System.Data;

public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? Stadium { get; set; }
    public ICollection<Match> Articles { get; set; }
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!;
    public ICollection<MatchEvent> MatchEvents { get; set; }
    public ICollection<MatchPlayer> MatchPlayers { get; set; }
}