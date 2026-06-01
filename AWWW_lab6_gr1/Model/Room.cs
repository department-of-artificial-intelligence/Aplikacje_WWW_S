using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public bool IsActive { get; set; }


        public int BuildingId { get; set; }
        public Building? Building { get; set; } //n
        public List<Reservation>? Reservations { get; set; } //n
        public List<RoomEquipment>? RoomEquipments { get; set; } //n
    }
}
