namespace AWWW_lab1_gr3.Models;

public class Article{
    public int Id {get; set;}
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime CreationDate {get; set;}
}