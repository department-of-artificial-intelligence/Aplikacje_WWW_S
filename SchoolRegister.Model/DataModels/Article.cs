using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Article
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Lead {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public DateTime CreationDate { get; set;}
    }
}