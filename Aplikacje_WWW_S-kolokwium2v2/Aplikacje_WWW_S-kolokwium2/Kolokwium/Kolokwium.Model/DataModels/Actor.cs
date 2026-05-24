using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //M Aktorow ma N seansow
        public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
    }
}
