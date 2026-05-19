using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Equipment
{
    public class IndexEquipmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa wyposażenia")]
        public string Name { get; set; } = null!;

        [Display(Name = "Opis")]
        public string? Description { get; set; }
    }
}
