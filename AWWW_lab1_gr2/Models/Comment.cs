namespace AWWW_lab1_gr2.Models;
public class Comment{
    public int Ind;
    public string ?Title;
    public string ?Content;
    public int ArticleId {get; set;}
    public Article Article {get; set;}=null!;
}