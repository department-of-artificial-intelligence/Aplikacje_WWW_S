namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Team
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Country { get; set;}
    public string City { get; set;}
    public DateTime FoundingDate { get; set;} 

    public List<Match> Match { get; set;}

    public int LeagueId { get; set;}
    public League League{ get; set;}

    public List<Player> Players { get; set;}

}
