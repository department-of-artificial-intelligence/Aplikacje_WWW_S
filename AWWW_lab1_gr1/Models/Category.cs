using AWWW_lab1_gr1.Models;
using System.ComponentModel.DataAnnotations;

namespace AWWW_lab1_gr1.Models;

public class Category
{ 
    
    public required int Id{get;set;}


    public string? Name{get;set;} 


    public ICollection<Article>? Articles{get;set;}
}