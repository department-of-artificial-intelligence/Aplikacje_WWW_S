using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Reservation
{
    public class CreateReservationViewModel
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }

        [Display(Name = "Sala lekcyjna")]
        [Required(ErrorMessage = "Musisz wybrać salę.")]
        public int RoomId { get; set; }
        public List<SelectListItem> Rooms { get; set; } = new();

        [Display(Name = "Czas rozpoczęcia")]
        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana.")]
        public DateTime StartTime { get; set; } = DateTime.Now.AddHours(1);

        [Display(Name = "Czas zakończenia")]
        [Required(ErrorMessage = "Data zakończenia jest wymagana.")]
        public DateTime EndTime { get; set; } = DateTime.Now.AddHours(2);
    }
}
