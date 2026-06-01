namespace Kolokwium.Services.DTO
{
    public class MealDto
    {
        public int Id {get; set; }

        public string? Type {get; set;}
        public bool IsVegetarian {get; set;}
        public string Description {get; set; } = string.Empty;

        public decimal Price {get; set; }
    }}