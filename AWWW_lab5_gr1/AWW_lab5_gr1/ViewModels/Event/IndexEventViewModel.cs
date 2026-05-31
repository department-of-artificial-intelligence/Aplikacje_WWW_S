namespace Web.ViewModels.Event
{
    public class IndexEventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public bool IsPublic { get; set; }
    }
}
