namespace AWWW_lab2_gr2.Models;
using System.Data;

public class Team
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public DateTime FoundingDate { get; set; }
    public int LeagueId { get; set; }
    public League League { get; set; } = null!;
    public ICollection<Match> Matches { get; set; }
    public ICollection<Player> Players { get; set; }
}