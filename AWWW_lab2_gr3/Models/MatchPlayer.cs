namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class MatchPlayer
{
    public int Id { get; set;}
    public DateTime StartTime { get; set;} 
    public DateTime EndTime { get; set;} 
    public int PlayerId { get; set;}
    public Player Player{ get; set;}

    public List<MatchPlayer> MatchPlayers { get; set;}

    public int PositionId { get; set;}
    public Position Position{ get; set;}

    public int MatchId { get; set;}
    public Match Match{ get; set;}{ get; set;}
}
