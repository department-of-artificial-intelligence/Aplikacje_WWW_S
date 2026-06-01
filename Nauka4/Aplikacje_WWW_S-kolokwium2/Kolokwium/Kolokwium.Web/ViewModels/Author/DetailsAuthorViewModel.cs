using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Services.DTO.Book;

namespace Kolokwium.Web.ViewModels.Author
{
    public class DetailsAuthorViewModel
    {
        public string FullName { get; set; } = null!;
        public List<BookDto> Books { get; set; } = new();
    }
}
