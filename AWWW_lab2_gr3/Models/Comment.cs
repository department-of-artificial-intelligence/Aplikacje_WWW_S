namespace AWWW_lab2_gr3.Models
{
    public class Comment
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Content {get; set;}
        public ICollection<Article> Articles {get; set;}
    }
}