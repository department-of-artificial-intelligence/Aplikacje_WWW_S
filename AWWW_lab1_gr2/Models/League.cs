namespace AWWW_lab1_gr2.Models;
public class League{
    public int Id;
    public string ?Name;
    public string ?Country;
    public int Level;
    public ICollection<Team> ?Teams {get; set;}
}