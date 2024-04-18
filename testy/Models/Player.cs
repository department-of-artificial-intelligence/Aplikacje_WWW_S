namespace Kolokwium.Models;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Country { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public ICollection<Position>? Positions { get; set; }
    public ICollection<MatchPlayer>? MatchPlayers { get; set; }
}