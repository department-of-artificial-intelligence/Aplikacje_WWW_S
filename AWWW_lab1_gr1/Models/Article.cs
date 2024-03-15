namespace AWWW_lab1_gr1.Models;
public class Article
{   
    public int ArticleId {get; set;}
    public string Title {get; set;}
    public string Content {get; set;}
    public DateTime CreationDate {get; set;}
    public ICollection<Comment> Comments {get;set;}
    public ICollection<Tag> Tags {get;set;}
}