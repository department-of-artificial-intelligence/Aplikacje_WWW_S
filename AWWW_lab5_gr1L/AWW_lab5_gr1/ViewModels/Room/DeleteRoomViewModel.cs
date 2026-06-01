using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.Room
{
    public class DeleteRoomViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa sali")]
        public string Name { get; set; } = null!;

        [Display(Name = "Z budynku")]
        public string BuildingName { get; set; } = null!;
    }
}
