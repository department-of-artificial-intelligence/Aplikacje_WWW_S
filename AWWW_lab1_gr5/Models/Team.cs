namespace AWWW_lab1_gr5.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime FoundingDate { get; set; }

        public virtual ICollection<Match>? HomeMatches { get; set; }
        public virtual ICollection<Match>? AwayMatches { get; set; }

        public int LeagueId { get; set; }
        public virtual League? League { get; set; }
        
        public virtual ICollection<Player>? Players { get; set; }

    }
}