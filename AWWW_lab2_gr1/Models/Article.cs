namespace AWWW_lab1_gr1.Models;
public class Article
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Content {get; set;}
    public DateTime CreationDate {get; set;}

    public Article(int Id, string Title, string Content, DateTime CreationDate)
    {
        this.Id = Id;
        this.Title = Title;
        this.Content = Content;
        this.CreationDate = CreationDate;
  }
}