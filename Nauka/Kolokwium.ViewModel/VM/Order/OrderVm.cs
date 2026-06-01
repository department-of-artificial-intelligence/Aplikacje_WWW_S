namespace Kolokwium.ViewModel.VM.Order
{
    public class OrderVm
    {
        public int Id {get; set;}
        public DateTime CreationDate {get; set;}
        public string ShippingAddress {get; set; } = string.Empty;
        public string? Description {get; set; }
        public string Status {get; set; } = string.Empty;

        public decimal TotalAmount {get; }
        public DateTime DueDate {get; set;}


    }
}