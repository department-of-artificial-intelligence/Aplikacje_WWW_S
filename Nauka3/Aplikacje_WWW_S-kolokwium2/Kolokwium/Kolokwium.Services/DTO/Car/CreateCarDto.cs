using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Car
{
    public class CreateCarDto
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int DriverId { get; set; }// Musimy przypisać auto do kierowcy przy tworzeniu!
    }
}
