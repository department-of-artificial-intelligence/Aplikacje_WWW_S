namespace AWWW_lab02_gr3.Models;

public class League
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public string Country {get; set;} = null!;
    public int Level {get; set;}

    public ICollection<Team>? Teams {get; set;}
}