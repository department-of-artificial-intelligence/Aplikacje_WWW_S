namespace AWWW_lab2_gr3.Models
{
    public class Article 
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Lead {get; set;}
        public string Content {get; set;}
        public DateTime CreationDate {get; set;}
        public ICollection<Comment> Comments {get; set;}
        public Category Category {get; set;}
        public ICollection<Author> Authors {get; set;}
        public ICollection<Tag> Tags {get; set;}
        public Match? Match {get; set;}
    }
}