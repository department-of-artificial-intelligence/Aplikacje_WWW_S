namespace AWWW_lab02_gr3.Models;

public class Author
{
    public int Id {get; set;}
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;

    public ICollection<Article>? Articles {get; set;}
}