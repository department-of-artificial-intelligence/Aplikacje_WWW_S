namespace AWWW_lab1_gr1.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; } = null!;
        public List<Article> Articles { get; set; } = null!;
        public Team HomeTeam { get; set; } = null!;
        public Team AwayTeam { get; set; } = null!;
        public Team HomeTeamId { get; set; } = null!;
        public Team AwayTeamId { get; set; } = null!;
        public List<MatchPlayer> MatchPlayers { get; set; } = null !;
        public List<MatchEvent> MatchEvents { get; set; } = null!;
    }
}
