using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO.Event
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}