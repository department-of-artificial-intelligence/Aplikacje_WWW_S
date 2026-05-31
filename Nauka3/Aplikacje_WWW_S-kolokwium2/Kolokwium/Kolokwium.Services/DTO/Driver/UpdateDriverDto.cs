using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Driver
{
    public class UpdateDriverDto
    {
        public int Id { get; set; } // Wymagane do edycji!
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
