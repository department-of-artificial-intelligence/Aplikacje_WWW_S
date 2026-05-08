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
        public string Title { get; set; } = null!;
        public string EventTypeName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsPublic { get; set; }
    }
}
