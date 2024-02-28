using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class Article
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public string Content{get;set;}
        public DateTime CreationDate{get;set;}
    }
}