namespace AWWW_lab1_gr5.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int AutorId { get; set; }
        public virtual Author Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? MatchId { get; set; }
        public virtual Match? Match { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}