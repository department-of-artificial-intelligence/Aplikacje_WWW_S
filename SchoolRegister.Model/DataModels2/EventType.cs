using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels2
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; } = new List<MatchEvent>();
    }
}