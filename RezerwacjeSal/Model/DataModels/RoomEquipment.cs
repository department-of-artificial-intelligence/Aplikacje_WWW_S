using System.ComponentModel.DataAnnotations.Schema;

namespace Model.DataModels
{
    public class RoomEquipment
    {
        public int Id { get; set; }

        public int RoomId { get; set; }
        public int EquipmentId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment? Equipment { get; set; }
    }
}
