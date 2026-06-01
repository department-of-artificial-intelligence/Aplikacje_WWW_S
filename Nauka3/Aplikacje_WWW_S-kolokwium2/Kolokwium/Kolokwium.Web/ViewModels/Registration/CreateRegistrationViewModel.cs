using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Registration
{
    public class CreateRegistrationViewModel
    {
        // ID samochodu przekazujemy w ukrytym polu, aby wiedzieć do którego auta przypisać dowód
        public int CarId { get; set; }

        [Required(ErrorMessage = "Numer dokumentu jest wymagany.")]
        [Display(Name = "Numer dowodu rejestracyjnego")]
        [StringLength(20, ErrorMessage = "Numer nie może przekraczać 20 znaków.")]
        public string DocumentNumber { get; set; } = string.Empty;//to samo co null!

        [Required(ErrorMessage = "Data wydania jest wymagana.")]
        [Display(Name = "Data wydania dokumentu")]
        [DataType(DataType.Date)] // Dzięki temu w HTML pokaże się ładny kalendarzyk do wyboru daty
        public DateTime IssueDate { get; set; } = DateTime.Now;
    }
}
