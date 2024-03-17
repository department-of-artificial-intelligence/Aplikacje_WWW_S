namespace AWWW_lab1_gr1.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Article> Articles { get; set; } = null!;
    }
}
