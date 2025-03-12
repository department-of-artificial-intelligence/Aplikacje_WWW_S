using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels2
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int EvenTypeId { get; set; }
        public EventType EventType { get; set; }
    }
}