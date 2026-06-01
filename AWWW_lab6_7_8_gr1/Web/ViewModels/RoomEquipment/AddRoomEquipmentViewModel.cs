namespace Web.ViewModels.RoomEquipment
{
    public class AddRoomEquipmentViewModel
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public string? BuildingName { get; set; }
        public List<AddRoomEquipmentViewModel> Items { get; set; } = new();
    }
}