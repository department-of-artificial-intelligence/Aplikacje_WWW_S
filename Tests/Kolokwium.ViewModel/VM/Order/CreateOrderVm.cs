namespace Kolokwium.ViewModel.VM.Order
{
    public class CreateOrderVm
    {
        public DateTime OrderDate {get;set;}
        public DateTime DeliveryDate {get;set;}
        public int DeliveryAddressId{get;set;}

        public List<int>MealIds{get;set;} =new();
    }
}