using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium.Services.DTO
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartTime { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; } // Zmapowane z powiązanej encji
    }
}
