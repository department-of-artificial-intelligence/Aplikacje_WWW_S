namespace AWWW_lab1_gr2.Models;
public class Position{
    public int Id;
    public string ?Name;
    public ICollection<Player> ?Players {get; set;}
}