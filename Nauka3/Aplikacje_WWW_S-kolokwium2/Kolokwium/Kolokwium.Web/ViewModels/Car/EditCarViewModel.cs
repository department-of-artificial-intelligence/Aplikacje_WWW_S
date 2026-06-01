using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Car
{
    public class EditCarViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Marka jest wymagana.")]
        [Display(Name = "Marka pojazdu")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Model jest wymagany.")]
        [Display(Name = "Model pojazdu")]
        public string Model { get; set; } = null!;

        [Required(ErrorMessage = "Musisz przypisać kierowcę.")]
        [Display(Name = "Kierowca")]
        public int DriverId { get; set; }

        // LISTA DO WYBORU KIEROWCY: Tego pola nie ma w DTO, jest tylko w ViewModelu pod formularz HTML!
        public List<SelectListItem> Drivers { get; set; } = new();
    }
}
