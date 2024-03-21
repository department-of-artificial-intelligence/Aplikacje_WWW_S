namespace AWWW_lab1_gr1.Models;

public class Player {
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Country { get; set; }
    public required DateTime BirthDate { get; set; }
    public required List<Position> Positions { get; set; }
    public List<MatchPlayer> MatchPlayers { get; set; }
    public required Team Team { get; set; }
}
