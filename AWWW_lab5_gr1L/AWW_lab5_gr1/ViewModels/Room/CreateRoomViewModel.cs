using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Room
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Pole Nazwa sali jest wymagane.")]
        [Display(Name = "Nazwa sali")]
        [StringLength(50, ErrorMessage = "Nazwa sali nie może przekraczać 50 znaków.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Wybór budynku jest wymagany.")]
        [Range(1, int.MaxValue, ErrorMessage = "Musisz wybrać poprawny budynek.")]
        [Display(Name = "Budynek")]
        public int BuildingId { get; set; }

        [Required(ErrorMessage = "Pole Pojemność jest wymagane.")]
        [Range(1, 1000, ErrorMessage = "Pojemność musi wynosić od 1 do 1000 miejsc.")]
        [Display(Name = "Pojemność")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Pole Piętro jest wymagane.")]
        [Display(Name = "Piętro")]
        public int Floor { get; set; }

        [Display(Name = "Czy sala jest aktywna?")]
        public bool IsActive { get; set; } = true;

        public List<SelectListItem>? Buildings { get; set; }
    }
}
