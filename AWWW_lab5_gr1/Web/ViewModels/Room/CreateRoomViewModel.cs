using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Room
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Pole Pojemność jest wymagane.")]
        [Range(1, int.MaxValue, ErrorMessage = "Pojemność musi być większa od 0.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Pole Piętro jest wymagane.")]
        public int Floor { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Musisz wybrać budynek.")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybrany budynek jest niepoprawny.")]
        public int BuildingId { get; set; }

        // Lista do elementu <select>, ignorowana w AutoMapperze
        public List<SelectListItem>? Buildings { get; set; }
    }
}