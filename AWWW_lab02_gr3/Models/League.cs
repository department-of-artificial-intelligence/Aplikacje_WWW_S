namespace AWWW_lab02_gr3.Models;

public class League
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Country {get; set;}
    public int Level {get; set;}

    public List<Team> Teams {get; set;}
}