using Kolokwium.Services.DTO.Car;

namespace Kolokwium.Web.ViewModels.Driver
{
    public class DetailsDriverViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<CarDto> Cars { get; set; } = new(); // Lista aut na ekranie szczegółów
    }
}
