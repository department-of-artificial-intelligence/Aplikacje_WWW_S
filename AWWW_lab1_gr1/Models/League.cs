namespace AWWW_lab1_gr1.Models;

public class League
{
    public int Id{get;set;}
    public required string Name{get;set;}

    public required string Country{get;set;}

    public int Level{get;set;}

    public ICollection<Team>? Teams{get;set;}
}