

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    // Navigation property for related books
    public virtual IList<Book> Books { get; set; } 
}
