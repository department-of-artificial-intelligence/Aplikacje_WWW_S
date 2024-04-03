namespace AWWW_lab1_gr1.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Team Team { get; set; } = null!;
        public List<MatchPlayer>? MatchPlayers { get; set; }
        public List<Position> Positions { get; set; } = null!;
    }
}
