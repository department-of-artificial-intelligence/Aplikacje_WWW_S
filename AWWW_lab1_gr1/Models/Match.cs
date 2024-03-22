namespace AWWW_lab1_gr1.Models;
public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Stadium { get; set; } = "";
    public ICollection<Article>? Articles { get; set; }

    public ICollection<MatchEvent>? MatchEvents { get; set; }
    public ICollection<MatchPlayer>? MatchPlayers { get; set; }

    public virtual Team AwayTeam { get; set; } = null!;
    public virtual Team HomeTeam { get; set; } = null!;

    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }


}