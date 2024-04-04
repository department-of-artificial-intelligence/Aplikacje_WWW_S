using System.ComponentModel.DataAnnotations;

namespace AWWW_lab1_gr1.Models;
public class Match
{
    [Key]
    public int id { get; set; }
    public DateTime Date { get; set; }
    public required ICollection<MatchEvent> MatchEvents { get; set; }

    public required ICollection<MatchPlayer> MatchPlayers{get;set;}
    public int Id { get; set; }
    public virtual Team HomeTeam{get; set;} = null!;
    public virtual Team AwayTeam{get; set;} = null!;
    public int HomeTeamId { get; internal set; }
    public int AwayTeamId { get; internal set; }
}