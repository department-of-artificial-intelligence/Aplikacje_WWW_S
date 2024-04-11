using System.ComponentModel.DataAnnotations;



namespace AWWW_lab1_gr1.Models;

public class Author
{
    
    public required int Id{get;set;}

   
    public required string FirstName {get;set;}

    
    public required string LastName{get;set;}
   
    
   public required ICollection<Article>? Articles{get;set;}
}

