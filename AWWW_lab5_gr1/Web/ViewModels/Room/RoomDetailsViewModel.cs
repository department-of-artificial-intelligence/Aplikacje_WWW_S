namespace Web.ViewModels.Room
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }
        public int BuildingId { get; set; }
        public string BuildingName { get; set; } = null!;
        public List<RoomEquipmentItemViewModel> Equipment { get; set; } = new();
    }
}
