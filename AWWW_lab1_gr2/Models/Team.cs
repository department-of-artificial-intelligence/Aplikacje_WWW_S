using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;

namespace AWWW_lab1_gr2.Models
{
    public class Team
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Country {get; set;}
        public string? City {get; set;}
        public DateTime FoundingDate {get; set;}
        public League? League {get; set;}
        public IList<Match>? HomeMatches {get; set;}
        public IList<Match>? AwayMatches {get; set;}
    }
}