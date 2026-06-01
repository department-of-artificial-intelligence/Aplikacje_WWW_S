namespace Kolokwium.Services.DTO.Meal
{
    public class MealDto
    {
        public int Id{get;set;}
        public string Type{get;set;} = string.Empty;
        public bool IsVegetarian{get;set;}
        public string Description{get;set;} = string.Empty;
        public decimal Price{get;set;}

    }
}