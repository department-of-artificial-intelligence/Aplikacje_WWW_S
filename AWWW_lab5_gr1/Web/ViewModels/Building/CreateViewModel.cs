using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Building
{
    public class CreateBuildingViewModel
    {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Pole Adres jest wymagane.")]
        public string Address { get; set; } = null!;

        public string? Description { get; set; }
    }
}