using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Building
{
    public class EditBuildingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Pole Adres jest wymagane.")]
        [Display(Name = "Adres")]
        public string Address { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
