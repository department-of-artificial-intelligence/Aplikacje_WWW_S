using System.Collections.Generic;

namespace Model.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMobile { get; set; }

        // Relacja 1:N z RoomEquipment
        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; } = new List<RoomEquipment>();
    }
}