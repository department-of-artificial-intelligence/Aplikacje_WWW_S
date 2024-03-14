using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public DateTime BirthDate { get; set; }

        public int TeamId {  get; set; }
        public virtual Team Team {  get; set; }

        public virtual ICollection<MatchPlayer> MatchPlayers {  get; set; }

    }
}