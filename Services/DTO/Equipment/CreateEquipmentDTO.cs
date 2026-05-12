using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Equipment
{
    public class CreateEquipmentDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMobile { get; set; }
    }
}
