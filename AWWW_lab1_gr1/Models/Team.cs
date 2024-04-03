namespace AWWW_lab1_gr1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime FoundingDate { get; set; }
        public List<Match>? HomeMatches { get; set; }
        public List<Match>? AwayMatches { get; set; }
        public League League { get; set; } = null!;
        public List<Player>? Player { get; set; }
    }
}
