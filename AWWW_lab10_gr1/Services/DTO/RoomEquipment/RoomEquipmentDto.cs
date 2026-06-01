using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.RoomEquipment
{
    public class RoomEquipmentDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = null!;

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = null!;
    }
}
