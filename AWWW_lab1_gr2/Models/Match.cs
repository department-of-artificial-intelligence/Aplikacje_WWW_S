namespace AWWW_lab1_gr2.Models;
public class Match{
    public int Id;
    public DateTime Date;
    public string ?Stadium;
    public ICollection<Article> Articles {get; set;}=null!;
}