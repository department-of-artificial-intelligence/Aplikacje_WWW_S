using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsMobile { get; set; }

        public virtual ICollection<RoomEquipment> RoomEquipments { get; set; }  = new List<RoomEquipment>();
    }
}