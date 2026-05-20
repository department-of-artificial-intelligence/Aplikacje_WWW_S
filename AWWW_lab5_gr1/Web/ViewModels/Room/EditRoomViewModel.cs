using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels.Room
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa sali jest wymagane.")]
        [Display(Name = "Nazwa sali")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Wybór budynku jest wymagany.")]
        [Display(Name = "Budynek")]
        public int BuildingId { get; set; }

        // Ta właściwość jest potrzebna AutoMapperowi, nawet jeśli jej nie wyświetlasz w formularzu
        public string? BuildingName { get; set; }

        [Required(ErrorMessage = "Pole Pojemność jest wymagane.")]
        [Range(1, 1000, ErrorMessage = "Pojemność musi wynosić od 1 do 1000.")]
        [Display(Name = "Pojemność")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Pole Piętro jest wymagane.")]
        [Display(Name = "Piętro")]
        public int Floor { get; set; }

        [Display(Name = "Czy sala jest aktywna?")]
        public bool IsActive { get; set; }

        // Lista budynków do kontrolki Select (Drop-down) na formularzu
        public List<SelectListItem> Buildings { get; set; } = new();
    }
}