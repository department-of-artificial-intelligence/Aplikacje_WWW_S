using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace AWWW_lab1_gr2.Models
{
    public class Articles
    {
        public int Id {get; set;}
        public string Title{get; set;}

        public string Content {get; set;}

        public DateTime CreationDate {get; set;}

    }
}