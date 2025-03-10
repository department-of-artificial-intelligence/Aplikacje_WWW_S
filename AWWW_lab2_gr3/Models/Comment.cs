namespace AWWW_lab2_gr3.Models;

public class Comments{
    public int Id { get; set;}
    public string Title { get; set;}
    public string Content { get; set;}

    public int ArticleId { get; set; }
    public Article Article { get; set; } = new Article();
}