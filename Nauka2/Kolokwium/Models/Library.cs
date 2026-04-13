namespace Kolokwium.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public int AuthorId { get; set; } 
        public Author Author { get; set; }

        public List<Book> Books { get; set; }
    }
}
