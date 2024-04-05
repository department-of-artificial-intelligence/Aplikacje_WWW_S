namespace AWWW_lab1_gr1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime FoundingDate { get; set; }
        public int LeagueId { get; set; }

        public League League { get; set; } = null!;
        public ICollection<Player>? Players { get; set; }
        public ICollection<Match>? HomeMatches { get; set; }
        public ICollection<Match>? AwayMatches { get; set; }
    }
}
