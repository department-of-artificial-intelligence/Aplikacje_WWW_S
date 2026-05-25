namespace Kolokwium.ViewModel.VM.Product
{
    public class CreateProductVm
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; } = new();
    }
}