using Microsoft.AspNetCore.SignalR;

namespace AWWW_lab1_gr1.Models;

public class Author{

    public int AuthorId{get; set;}
    public string FirstName{get;set;} = ""; 
    public string LastName{get;set;} ="";
    public List<Article>? Articles{get;set;}
}