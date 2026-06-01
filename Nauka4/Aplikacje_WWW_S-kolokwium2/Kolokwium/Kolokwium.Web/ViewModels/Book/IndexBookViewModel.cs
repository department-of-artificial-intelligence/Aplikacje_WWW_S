using Kolokwium.Services.DTO.Author;

namespace Kolokwium.Web.ViewModels.Book
{
    public class IndexBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
    }
}
