namespace AS_l2.Models
{
    public static class Repository
    {
        private static readonly ICollection<Article> articles = new List<Article>();
        public static ICollection<Article> Articles => articles;
        public static void AddArticle(Article article)
        {
            if (articles.Count > 0)
            {
                var id = articles.Last().Id;
                article.Id = ++id;
            }
            else
                article.Id = 0;
            article.CreationDate = DateTime.Now;
            articles.Add(article);
        }
    }
}
