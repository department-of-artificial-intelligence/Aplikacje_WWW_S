using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Room
{
    public class IndexRoomViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa sali")]
        public string Name { get; set; } = null!;

        [Display(Name = "Budynek")]
        public string BuildingName { get; set; } = null!;

        [Display(Name = "Pojemność")]
        public int Capacity { get; set; }

        [Display(Name = "Piętro")]
        public int Floor { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
