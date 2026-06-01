using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Car
{
    public class DeleteCarViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Marka pojazdu")]
        public string Brand { get; set; } = null!;

        [Display(Name = "Model pojazdu")]
        public string Model { get; set; } = null!;
    }
}
