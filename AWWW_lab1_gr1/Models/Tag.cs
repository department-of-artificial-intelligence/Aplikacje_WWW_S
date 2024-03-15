namespace AWWW_lab1_gr1.Models;
public class Tag{
   public int Id{get; set;}
   public string Name {get;set;}

   public virtual ICollection<Article> Article {get;set;}
}