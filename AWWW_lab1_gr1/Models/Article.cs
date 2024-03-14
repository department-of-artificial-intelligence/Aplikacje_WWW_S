using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AWWW_lab1_gr1.Models;

public class Article
{ 
    public required int ID{get;set;}
    public string? Title{get;set;} 
 
    public string? Lead{get;set;} 
  
    public string? Content {get;set;} 
    
    public required DateTime CreationDate{get;set;}

    public  required Author Authors{get;set;} 

    public required ICollection<Comment> Comments{get;set;}

    
    public required Category Category{get;set;}

    public required ICollection<Tag> Tags{get;set;}
     
    public Match? Match{get;set;}
}