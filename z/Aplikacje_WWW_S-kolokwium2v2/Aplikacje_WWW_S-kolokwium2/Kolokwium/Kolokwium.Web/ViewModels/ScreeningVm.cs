using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.ViewModel.VM
{
    public class ScreeningVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł filmu jest wymagany")]
        [Display(Name = "Tytuł Filmu")]
        public string MovieTitle { get; set; }

        [Required(ErrorMessage = "Data seansu jest wymagana")]
        [Display(Name = "Data i Godzina Rozpoczęcia")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Wybór kina jest wymagany")]
        [Display(Name = "Kino")]
        public int CinemaId { get; set; }

        [Display(Name = "Nazwa Kina")]
        public string CinemaName { get; set; }
    }
}