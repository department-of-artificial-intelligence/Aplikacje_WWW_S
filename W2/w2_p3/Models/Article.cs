using Azure;

namespace w2_p3.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Lead { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        //1 - *
        //komentarz na temat virtual...
        public virtual Author Author { get; set; } = null!;
        public int AuthorId { get; set; }
        //1 - *
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        //* - *
        public ICollection<Tag>? Tags { get; set; }
        //1 - 1
        public ArticleMetaData? ArticleMetaData { get; set; }
    }
}
