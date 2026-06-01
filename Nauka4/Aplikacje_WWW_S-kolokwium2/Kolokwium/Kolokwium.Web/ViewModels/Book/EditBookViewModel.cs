using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Web.ViewModels.Book
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

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

        // 3. Lista wielokrotnego wyboru (multiselect lub checkboxy) dla Autorów
        public List<SelectListItem> Authors { get; set; } = new();
    }
}
