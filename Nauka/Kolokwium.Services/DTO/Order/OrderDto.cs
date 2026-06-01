namespace Kolokwium.Services.DTO.Order
{
    public class OrderDto
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