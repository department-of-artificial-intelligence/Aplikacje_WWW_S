using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Car
{
    public class CarDetailsDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;

        // POWIĄZANIE 1 do Wielu: Dane kierowcy
        public int DriverId { get; set; }
        public string DriverFirstName { get; set; } = null!;
        public string DriverLastName { get; set; } = null!;

        // POWIĄZANIE 1 do 1: Dane dowodu rejestracyjnego
        public string? DocumentNumber { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
