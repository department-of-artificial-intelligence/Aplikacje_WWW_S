namespace AWWW_lab02_gr3.Models;

public class Category
{
    public int Id {get; set;}
    public string Name {get; set;}

    public List<Article> Articles {get; set;}
}