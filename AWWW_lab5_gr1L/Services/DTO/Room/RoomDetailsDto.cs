using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO.RoomEquipment;

namespace Services.DTO.Room
{
    public class RoomDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int Floor {  get; set; }
        public bool IsActive { get; set; }
         public int BuildingId { get; set; }
        public string BuildingName { get; set; } = null!;
        public List<RoomEquipmentItemDto> Equipment{ get; set; }
    }
}
