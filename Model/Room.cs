using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Room {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }
    }
}
