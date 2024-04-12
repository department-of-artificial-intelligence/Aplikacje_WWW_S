

namespace AWWW_lab1_gr1.Models;

public class Tag
{
    public int Id{get;set;}
    public required string Name{get;set;}

    public  required ICollection<Article>? Articles{get;set;}
}