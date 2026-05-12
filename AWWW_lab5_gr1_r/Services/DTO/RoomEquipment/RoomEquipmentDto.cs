namespace Services.DTO.RoomEquipment
{
    public class RoomEquipmentItemDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}