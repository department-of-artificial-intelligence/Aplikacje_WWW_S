using Kolokwium.Services.DTO.Car;

namespace Kolokwium.Web.ViewModels.Car
{
    public class IndexCarViewModel
    {
        public List<CarDto> Cars { get; set; } = new();
    }
}
