using System;

namespace Kolokwium.ViewModel.VM
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowDetails { get; set; }
        public Exception? Exception { get; set; }
        public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
    }
}