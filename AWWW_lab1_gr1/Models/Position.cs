namespace AWWW_lab1_gr1.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<MatchPlayer> MatchPlayers { get; set; } = null!;
        public List<Player> Players { get; set; } = null!;
    }
}
