namespace AWWW_lab1_gr1.Models;


public class Category{
    public int CategoryId{get; set;}
    public int Name{get;set;}
    public List<Article> Articles{get;set;}
}