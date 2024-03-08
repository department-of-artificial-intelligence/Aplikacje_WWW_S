namespace AWWW_lab1_gr2.Models;
public class Tag{
    public int Id;
    public string ?Name;
    public ICollection<Article> Articles {get; set;}=null!;
}