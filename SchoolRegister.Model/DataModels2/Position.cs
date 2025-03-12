using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels2
{
    public class Position
    {
        

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}