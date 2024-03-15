namespace AWWW_lab1_gr2.Models;
public class Comment{
    public int Id { get; set; }
    public string ?Title { get; set; }
    public string ?Content { get; set; }
    public int ArticleId {get; set;}
    public Article Article {get; set;}=null!;
}