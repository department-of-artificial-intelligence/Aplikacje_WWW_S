namespace AWWW_lab1_gr2.Models
{
    public class Category
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public IList<Article>? Articles{get; set;}
    }
}