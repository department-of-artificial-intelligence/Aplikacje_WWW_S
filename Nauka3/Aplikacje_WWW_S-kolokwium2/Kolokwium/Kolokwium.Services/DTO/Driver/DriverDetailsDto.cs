using Kolokwium.Services.DTO.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Driver
{
    public class DriverDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // POWIĄZANIE: Lista aut tego kierowcy
        public List<CarDto> ?Cars { get; set; } = new ();
    }
}
