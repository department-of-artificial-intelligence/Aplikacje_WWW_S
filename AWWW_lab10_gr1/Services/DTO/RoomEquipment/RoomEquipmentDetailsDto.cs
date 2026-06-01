namespace Services.DTO.RoomEquipment
{
    public class RoomEquipmentDetailsDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int RoomId { get; set; }
        public string? RoomName { get; set; }

        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
    }
}