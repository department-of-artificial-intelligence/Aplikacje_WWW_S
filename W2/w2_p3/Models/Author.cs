namespace w2_p3.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        //komentarz na temat virtual
        public virtual ICollection<Article>? Articles { get; set; }

    }
}
