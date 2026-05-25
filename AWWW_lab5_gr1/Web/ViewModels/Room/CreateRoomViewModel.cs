using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels.Room
{
    public class CreateRoomViewModel
    {
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [MaxLength(50, ErrorMessage = "Pole Nazwa może mieć maksymalnie 50 znaków.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Pojemność")]
        [Required(ErrorMessage = "Pole Pojemność jest wymagane.")]
        [Range(1, int.MaxValue, ErrorMessage = "Pole Pojemność musi być większe od zera.")]
        public int? Capacity { get; set; }

        [Display(Name = "Piętro")]
        [Required(ErrorMessage = "Pole Piętro jest wymagane.")]
        public int? Floor { get; set; }

        [Display(Name = "Aktywna")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Budynek")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz budynek.")]
        public int BuildingId { get; set; }

        public List<SelectListItem> Buildings { get; set; } = new();
    }
}
