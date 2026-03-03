namespace AWWW_lab1_gr1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }


        public Article(int id, string title, string content, DateTime creationDate)
        {
            Id = id;
            Title = title;
            Content = content;
            CreationDate = creationDate;
        }
    }
}