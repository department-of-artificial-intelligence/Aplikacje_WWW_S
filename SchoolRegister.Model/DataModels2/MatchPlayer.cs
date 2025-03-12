using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels2
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }
    }
}