using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Equipment
{
    public class CreateEquipmentDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsMobile { get; set; }
    }
}
