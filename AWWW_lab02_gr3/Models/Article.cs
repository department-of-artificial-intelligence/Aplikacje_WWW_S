namespace AWWW_lab02_gr3.Models
{
    public class Article

    {
        public int Id {get; set; }
        public string Title { get; set; } = null!;
        public string Content {get; set; } = null!;
        public DateTime CreationDate { get; set; }

        public List<Comment>? Comments {get; set;}

        public List<Tag>? Tags {get; set;}

        public int AuthorId {get; set;}
        public Author? Author {get; set;}
        
        public int CategoryId {get; set;}
        public Category? Category {get; set;}
        
        public int? MatchId {get; set;}
        public Match? Match {get; set;}
    }
}