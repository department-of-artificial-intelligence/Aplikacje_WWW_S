using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; } = "Dostępna"; // Status jako string z domyślną wartością

        // Klucz obcy i właściwość nawigacyjna do Wydawnictwa (1:N)
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
