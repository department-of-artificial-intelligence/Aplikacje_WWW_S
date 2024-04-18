namespace Kolokwium.Models;

public class Match
{
    public int Id { get; set; }
    public DateTime? Date { get; set; }
    public string? Stadium { get; set; }
    public int? HomeTeamId { get; set; }
    public int? AwayTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;
    public Team AwayTeam { get; set; } = null!;
    public ICollection<MatchPlayer>? MatchPlayers { get; set; }
}