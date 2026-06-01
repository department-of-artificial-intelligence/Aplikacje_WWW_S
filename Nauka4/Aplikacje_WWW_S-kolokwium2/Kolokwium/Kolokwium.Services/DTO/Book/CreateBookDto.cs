using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Book
{
   public class CreateBookDto
    {
        public string Title { get; set; } = null!;
        public string Status { get; set; } = "Dostępna";

        public int PublisherId { get; set; } // ID wybranego wydawnictwa z selecta

        // KLUCZ RELACJI M:N: Lista identyfikatorów autorów zaznaczonych na formularzu
        public List<int> AuthorIds { get; set; } = new();
    }
}
