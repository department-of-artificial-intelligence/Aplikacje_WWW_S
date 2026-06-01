using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Book
{
    public class UpdateBookDto
    {
        public int Id { get; set; } // Identyfikator edytowanej książki (kluczowe!)
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PublisherId { get; set; }

        // Podczas edycji użytkownik może zmienić autorów (dodać nowych / usunąć starych)
        public List<int> AuthorIds { get; set; } = new();
    }
}
