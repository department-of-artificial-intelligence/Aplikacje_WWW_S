using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_lab2_gr2.Models
{
    public class comment
    {
        public int Id {get; set;}
        public string title {get; set;}
        public string content{get;set;}
        public Articles artykul{get;set;}=null!;
    }
}