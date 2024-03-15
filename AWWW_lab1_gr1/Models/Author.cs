namespace AWWW_lab1_gr1.Models;

public class Author{
    
    public ICollection <Article> Articles{get;set;}
    public int ID{get; set;}
    
    public string FirstName{get; set;}

    public string LastName{get; set;}
}