namespace AWWW_lab02_gr3.Models
{
    public class Article

    {
        public int Id {get; set; }
        public string Title { get; set; } = null!;
        public string Content {get; set; } = null!;
        public DateTime CreationDate { get; set; }

        public ICollection<Comment>? Comments {get; set;}

        public ICollection<Tag>? Tags {get; set;}

        public int AuthorId {get; set;}
        public Author Author {get; set;} = null!;
        
        public int CategoryId {get; set;}
        public Category Category {get; set;} = null!;
        
        public int? MatchId {get; set;}
        public Match? Match {get; set;}
    }
}