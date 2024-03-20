namespace AWWW_lab1_gr5.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int AutorId { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}