namespace Kolokwium.ViewModel.VM
{
    public class OrderVm
    {
        public int Id {get; set; }
        public DateTime OrderDate {get; set;}
        public DateTime DeliveryDate {get; set;}
        public decimal TotalPrice {get; set; }

        public int DeliveryAddressId { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;

        public List<string> Meals {get; set; } = new();
    }
}