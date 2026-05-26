using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.ViewModel.VM
{
    public class CreateScreeningVm
    {
        [Required(ErrorMessage = "Pole Tytuł filmu jest wymagane.")]
        [Display(Name = "Tytuł filmu")]
        public string MovieTitle { get; set; } = null!;

        [Required(ErrorMessage = "Pole Data i godzina jest wymagane.")]
        [Display(Name = "Data i godzina rozpoczęcia")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Wybór kina jest wymagany.")]
        [Display(Name = "Identyfikator Kina (ID)")]
        public int CinemaId { get; set; }
    }
}