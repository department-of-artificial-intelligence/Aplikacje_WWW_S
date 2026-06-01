using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
        // Relacja M:N (Autor ma wiele książek)
        public virtual ICollection<Book> Books { get; set; }
    }
}
