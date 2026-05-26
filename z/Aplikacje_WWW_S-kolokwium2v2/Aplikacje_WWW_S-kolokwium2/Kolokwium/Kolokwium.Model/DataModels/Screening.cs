using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Screening
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartTime { get; set; }

        //Klucz obcy do Cinema (1:N)
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; } = null!;

        //Relacja N:M do Actor
        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
    }
}