using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoomEquipment
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

    }
}
