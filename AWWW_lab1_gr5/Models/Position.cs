namespace AWWW_lab1_gr5.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

        public virtual ICollection<Player>? Players { get; set; }
    }
}