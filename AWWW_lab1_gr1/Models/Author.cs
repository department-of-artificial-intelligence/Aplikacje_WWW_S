using Microsoft.AspNetCore.SignalR;

namespace AWWW_lab1_gr1.Models;

public class Author{

    public int AuthorId{get; set;}
    public string FirtstName{get;set;} = ""; 
    public string LastName{get;set;} ="";
    public ICollection<Article> Articles{get;set;}
}