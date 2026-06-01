using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Services.DTO.Book;

namespace Kolokwium.Services.DTO.Author
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public List<BookDto> Books { get; set; } = new();
    }
}
