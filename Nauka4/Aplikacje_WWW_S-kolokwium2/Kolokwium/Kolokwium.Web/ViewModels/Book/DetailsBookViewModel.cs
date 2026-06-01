using Kolokwium.Services.DTO.Author;

namespace Kolokwium.Web.ViewModels.Book
{
    public class DetailsBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;

        public List<AuthorDto> Authors { get; set; } = new();
    }
}
