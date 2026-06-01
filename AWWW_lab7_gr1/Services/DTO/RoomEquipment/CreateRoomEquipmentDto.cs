using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.RoomEquipment
{
    public class CreateRoomEquipmentDto
    {
        public int Quantity { get; set; }

        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
    }
}
