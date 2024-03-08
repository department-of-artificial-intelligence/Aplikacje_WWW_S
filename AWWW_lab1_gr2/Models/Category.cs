namespace AWWW_lab1_gr2.Models;
public class Category{
    public int Id;
    public string ?Name;
    public ICollection<Article> Articles {get; set;}=null!;
}