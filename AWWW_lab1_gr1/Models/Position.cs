namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class Position{
    public int ID{get; set;}
    public required string Name{get;set;}
    public ICollection<MatchPlayer>? MatchPlayers { get; set; }  
    public ICollection<Player>? Players { get; set; }
}