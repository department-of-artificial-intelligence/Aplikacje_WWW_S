namespace AWWW_lab1_gr2.Models;
public class Article{
    public int Id {get; set;}
    public string ?Title {get; set;}
    public string ?Lead {get; set;}
    public string ?Content {get; set;}
    public DateTime CreationDate {get; set;} 
    public int AuthorId {get; set;}
    public Author Author {get; set;}=null!;
    public int CategoryId {get; set;}
    public Category Category {get; set;}=null!;
    public int? MatchId {get; set;}
    public Match ?Match {get; set;}
    public ICollection<Comment> Comments {get; set;}=null!;
    public ICollection<Tag> Tags {get; set;}=null!;





}