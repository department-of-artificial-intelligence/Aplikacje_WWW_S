using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher
    {
        public IList<Subject> Subjects { get; set; }
        public string Title { get; set; }
        
    }
}