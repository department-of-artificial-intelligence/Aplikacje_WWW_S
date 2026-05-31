using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Model.DataModels
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
