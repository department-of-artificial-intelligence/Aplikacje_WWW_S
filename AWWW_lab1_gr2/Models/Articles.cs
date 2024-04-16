namespace AWWW_lab1_gr2.Models{
    public class Article{
        public int Id{get;set;}
        public string? Lead{get;set;}
        public string? Title{get;set;}
        public string? Content{get;set;}
        public DateTime CreationDate{get;set;}
        public Author? Author{get;set;}
        public IList<Tag>? Tags{get;set;}
    }
}