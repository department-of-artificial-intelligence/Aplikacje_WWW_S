namespace Web.ViewModels
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowDetails { get; set; }
        public Exception?  Exception { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
