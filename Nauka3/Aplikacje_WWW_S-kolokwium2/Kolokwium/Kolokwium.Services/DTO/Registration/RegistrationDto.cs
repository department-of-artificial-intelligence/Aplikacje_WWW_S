using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO.Registration
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public DateTime IssueDate { get; set; }

    }
}
