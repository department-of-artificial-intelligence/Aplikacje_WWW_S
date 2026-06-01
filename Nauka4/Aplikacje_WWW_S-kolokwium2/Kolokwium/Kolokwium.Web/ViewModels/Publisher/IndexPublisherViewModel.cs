using Kolokwium.Services.DTO.Book;
using Kolokwium.Services.DTO.Publisher;
namespace Kolokwium.Web.ViewModels.Publisher
{
    public class IndexPublisherViewModel
    {
        public string Name { get; set; } = null!;
        public List<PublisherDto> Publishers { get; set; } = new();
        public List<BookDto> Books { get; set; } = new();
    }
}
