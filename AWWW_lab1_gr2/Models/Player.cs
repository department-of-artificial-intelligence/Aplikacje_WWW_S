namespace AWWW_lab1_gr2.Models;
public class Player{
    public int Id;
    public string ?FirstName;
    public string ?LastName;
    public string ?Country;
    public DateTime BirthDate;
    public int TeamId {get; set;}
    public Team Team {get; set;}=null!;

}