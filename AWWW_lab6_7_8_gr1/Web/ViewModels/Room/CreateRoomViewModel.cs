using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Room
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Nazwa sali jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pojemność jest wymagana")]
        [Display(Name = "Pojemność")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Piętro jest wymagane")]
        [Display(Name = "Piętro")]
        public int Floor { get; set; }

        [Display(Name = "Aktywna")]
        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Wybór budynku jest wymagany")]
        [Display(Name = "Budynek")]
        public int BuildingId { get; set; }

        public List<SelectListItem> Buildings { get; set; } = new();
    }
}