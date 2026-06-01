using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Status jest wymagany.")]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Dostępna";

        [Required(ErrorMessage = "Wydawca jest wymagany.")]
        [Display(Name = "Wydawca")]
        public int PublisherId { get; set; }

        // 1. Lista rozwijana (dropdown) dla Wydawcy (Relacja 1:N)
        public List<SelectListItem> Publishers { get; set; } = new();

        // 2. Przechowuje ID autorów, którzy aktualnie/nowo zostali wybrani w formularzu (Relacja M:N)
        [Display(Name = "Autorzy")]
        public List<int> AuthorIds { get; set; } = new();

        //public int AuthorId { get; set; } Jakby byla 1 do 1 to zmieniasz tylko tu i w mapowaniach obydwoch no i widok na selecta

        // 3. Lista wielokrotnego wyboru (multiselect lub checkboxy) dla Autorów
        public List<SelectListItem> Authors { get; set; } = new();
    }
}
