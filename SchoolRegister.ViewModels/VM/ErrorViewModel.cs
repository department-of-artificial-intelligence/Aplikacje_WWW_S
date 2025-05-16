using System;

namespace SchoolRegister.ViewModels.VM {
    public class ErrorViewModel {
        public required string RequestId {get;set;}

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}