namespace Kolokwium.Services.DTO.Order
{
    public class OrderDto
    {
        public int Id{get;set;}
        public DateTime OrderDate {get;set;}
        public DateTime DeliveryDate {get;set;}
        public decimal TotalPrice{get;set;}

        public int DeliveryAddressId{get;set;} 

        public string Country{get;set;} = string.Empty;
        public string City{get;set;} = string.Empty;
        public string Street{get;set;} = string.Empty;
        public List<string> Meals{get;set;} = new();

    }
}