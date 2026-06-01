using Kolokwium.Services.DTO.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Web.ViewModels.Author
{
    public class IndexAuthorViewModel
    {
        // public int Id { get; set; } Jakbym nie chcial robic Lista
        //  public string FullName { get; set; } = null!;

        public List<AuthorDto> Authors { get; set; } = new();
    }
}
