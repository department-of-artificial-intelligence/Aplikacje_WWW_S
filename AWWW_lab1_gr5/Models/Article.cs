using System.Data;
namespace AWWW_lab1_gr5.Models;

public class Article
{ 
    public required int Id {get;set;}
    public string Title { get; set; } = null!;
 
    public string Lead {get;set; } = null!;

    public string Content {get;set; } = null!;

    public required DateTime CreationDate{get;set;}

    public  required Author Authors{get;set;} 

    public required ICollection<Comment> Comments{get;set;}

    
    public required Category Category{get;set;}

    public required ICollection<Tag> Tags{get;set;}
     
    public Match? Match{get;set;}
}