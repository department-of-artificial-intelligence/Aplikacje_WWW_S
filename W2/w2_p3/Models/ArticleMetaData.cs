namespace w2_p3.Models
{
    public class ArticleMetaData
    {
        public int Id { get; set; }
        public string FontFamily { get; set; } = null!;
        public int FontSize { get; set; }
        public Article? Article { get; set; }
        public int? ArticleId { get; set; }

    }
}
