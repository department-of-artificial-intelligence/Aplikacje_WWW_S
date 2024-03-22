namespace AWWW_lab1_gr1.Models;
public class Article{
   public int Id{get; set;}
   public string? Title {get; set;}
   public string? Lead {get;set;}
   public string? Content {get;set;}
   public DateTime CreationDate {get; set;}
   public Author Author{get;set;}
   public int AuthorId {get;set;}
   public virtual ICollection<Comment> Coments {get;set;}
   public int CategoryId {get;set;}
   public Category Category {get;set;}
   public virtual ICollection<Tag> Tags {get;set;}
}