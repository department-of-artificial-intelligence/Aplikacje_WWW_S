using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace AWWW_lab1_gr5.Controllers
{
    public class Author
    {
        public int Id {get;set;}
        
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public virtual ICollection<Article> Articles{get;set;}
    }
}