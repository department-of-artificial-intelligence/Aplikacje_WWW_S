namespace AWWW_lab1_gr2.ViewModels {
    public class ErrorViewModel {
        public string? RequestId {get; set;}
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); 
    }
}