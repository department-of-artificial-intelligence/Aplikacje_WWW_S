public class Team{
    public int ID{get; set;}
    public required string Name{get;set;}
    public required string Country{get;set;}
    public required string City{get;set;}
    public DateTime FoundingDate{get;set;}
    public List<Player>? Players { get; set; }

    public required League League { get; set; }
}