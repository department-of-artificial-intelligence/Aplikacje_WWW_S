using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; } = null!;

        // Relacja 1:N z Screening
        public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
