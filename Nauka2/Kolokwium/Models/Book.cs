using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        [Precision(18, 4)]
        public decimal Price { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }

        public int AuthorId { get; set; } 
        public Author Author { get; set; }
        //public List<Author> Authors { get; set; }
    }
}
