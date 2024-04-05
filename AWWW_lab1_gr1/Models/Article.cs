namespace AWWW_lab1_gr1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Lead { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int? MatchId { get; set; }

        public Author Author { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Match? Match { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}