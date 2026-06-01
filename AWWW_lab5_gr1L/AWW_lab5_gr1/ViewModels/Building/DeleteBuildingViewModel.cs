using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Building
{
    public class DeleteBuildingViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; } = null!;

        [Display(Name = "Adres")]
        public string Address { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
