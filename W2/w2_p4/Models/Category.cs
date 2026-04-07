namespace w2_p4.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Article>? Articles { get; set; }
    }
}
