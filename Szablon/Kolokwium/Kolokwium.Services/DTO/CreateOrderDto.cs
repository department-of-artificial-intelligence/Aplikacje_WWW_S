using Kolokwium.Model.DataModels;

namespace Kolokwium.Services.DTO
{
    public class CreateOrderDto{
        public DateTime OrderDate {get; set;}
        public DateTime DeliveryDate {get; set;}

        public int DeliveryAddressId {get; set;}

        public List<int> MealIds {get; set; } = new();
}
}