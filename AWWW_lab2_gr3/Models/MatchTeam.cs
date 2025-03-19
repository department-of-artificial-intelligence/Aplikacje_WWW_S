using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_lab2_gr3.Models{
    public class MatchTeam
    {
    public int MatchId { get; set; }
    public Match Match { get; set; }

    public int TeamId { get; set; }
    public Team Team { get; set; }
    }
}