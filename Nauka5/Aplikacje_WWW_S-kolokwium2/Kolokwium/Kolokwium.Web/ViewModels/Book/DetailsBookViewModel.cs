using Kolokwium.Model.DataModels;

namespace Kolokwium.Web.ViewModels.Book
{
    public class DetailsBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Status { get; set; } = null!;

        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;

        public List<Author> Authors { get; set; } = new();
        //public List<string>AuthorNames {get; set;} = new();
        /*Takby bylo widoku jakby bylo stringiem @foreach (var authorName in Model.AuthorNames)
        {
            <li><i class="fa fa-user"></i> @authorName</li> }*/
    }
}
