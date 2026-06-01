using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja 1:N (Wydawnictwo ma wiele książek)
        public virtual ICollection<Book> Books { get; set; }
    }
}
