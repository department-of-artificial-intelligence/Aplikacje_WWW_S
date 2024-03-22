using System.Net.NetworkInformation;

namespace AWWW_lab1_gr1.Models{
    public class League{
        public int ID{get; set;}
        public required string Name{get;set;}
        public required string Country{get;set;}
        public int Level{get; set;}
        public virtual ICollection<Team>? Teams { get; set; }
    }
}