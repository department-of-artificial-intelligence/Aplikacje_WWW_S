public class League {
    public int Id { get; set; }

    public required string Name { get; set; }

    public List<Team>? Teams { get; set; }
    public required string Country { get; set; }

    public required int Level { get; set; }
}