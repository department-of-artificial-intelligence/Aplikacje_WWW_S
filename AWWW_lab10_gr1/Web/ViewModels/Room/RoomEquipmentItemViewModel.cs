namespace Web.ViewModels.Room
{
    public class RoomEquipmentItemViewModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
