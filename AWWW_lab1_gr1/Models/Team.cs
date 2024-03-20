public class Team {
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Country { get; set; }

    public required string City { get; set; }

    public required DateTime FoundingDate { get; set; } 

    public virtual ICollection<Match>? HomeMatches { get; set; }
    public virtual ICollection<Match>? AwayMatches { get; set; }

    public List<Player>? Players { get; set; }

    public required League League { get; set; }
}