namespace AWWW_lab02_gr3.Models;

public class Tag
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;

    public ICollection<Article>? Articles {get; set;}
}