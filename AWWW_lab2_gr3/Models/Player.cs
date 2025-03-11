namespace AWWW_lab2_gr3.Models;

public class Player {
    public int Id { get; set;}  
    public string FirstName { get; set;}
    public int LastName { get; set;}
    public string Country { get; set;}
    public DateTime BirthDate { get; set;}


    public int TeamId { get; set; }
    public virtual Team Team { get; set; }

    public ICollection<MatchPlayer> MatchPlayer { get; set; }
    public ICollection<Position> Position { get; set; }
}