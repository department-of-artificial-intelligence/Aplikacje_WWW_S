public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    // Navigation property for related books
    public virtual IList<Book> Books { get; set; } = new List<Book>();
}