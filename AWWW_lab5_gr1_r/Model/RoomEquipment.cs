namespace Model.Entities
{
    public class RoomEquipment
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual Equipment Equipment { get; set; } = null!;
    }
}