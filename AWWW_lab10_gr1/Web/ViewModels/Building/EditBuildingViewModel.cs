using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Building
{
    public class EditBuildingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [MaxLength(100, ErrorMessage = "Pole Nazwa może mieć maksymalnie 100 znaków.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Pole Adres jest wymagane.")]
        [MaxLength(200, ErrorMessage = "Pole Adres może mieć maksymalnie 200 znaków.")]
        public string Address { get; set; } = null!;

        [Display(Name = "Opis")]
        [MaxLength(500, ErrorMessage = "Pole Opis może mieć maksymalnie 500 znaków.")]
        public string? Description { get; set; }
    }
}
