using Kolokwium.Services.DTO.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Book
{
   public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;

        // Relacja M:N - kolekcja autorów przypisanych do danej książki
        public List<AuthorDto> Authors { get; set; } = new();
    }
}
