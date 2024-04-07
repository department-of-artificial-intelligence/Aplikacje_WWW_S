namespace AWWW_lab1_gr1.Models;
using Microsoft.EntityFrameworkCore;
public class Category{
    public int ID{get; set;}
    public required string Name{get;set;}
    public List<Article>? Articles{get;set;}

}