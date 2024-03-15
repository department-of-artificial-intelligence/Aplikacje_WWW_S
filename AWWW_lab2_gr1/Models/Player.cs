namespace AWWW_lab1_gr1.Models;
public class Player
{
    public int Id{get;set;}
    public string? FirstName{get;set;}
    public string? LastName{get;set;}

    public string? Country{get;set;}
    public DateTime BirthDate{get;set;}

    public Team? Team{get;set;}
    public ICollection<Position>? Positions{get;set;}
    public ICollection<MatchPlayer>? MatchPlayers{get;set;}

}