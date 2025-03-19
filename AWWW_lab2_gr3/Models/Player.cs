namespace AWWWW_lab2_gr3.Models;

using System.Data;
using Microsoft.AspNetCore.Mvc;

public class Player
{
    public int Id { get; set;}
    public string FirstName { get; set;}
    public string LastName{ get; set;}
    public string Country{ get; set;}
    public DateTime BirthDate { get; set;} 

    public int TeamId { get; set;}
    public Team Team{ get; set;}
    public List<MatchPlayer> MatchPlayers { get; set;}

    public int PositionId { get; set;}
    public Position Position{ get; set;}

}
