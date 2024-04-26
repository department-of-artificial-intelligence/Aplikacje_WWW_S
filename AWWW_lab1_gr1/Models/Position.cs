using Microsoft.EntityFrameworkCore;

public class Position
{

    public int Id { get; set; }

    public required string Name { get; set; }

    public List<Player>? Players { get; set; }

    public List<PlayerPosition>? PlayerPositions { get; set; }

    public List<MatchPlayer>? MatchPlayers { get; set; }


}