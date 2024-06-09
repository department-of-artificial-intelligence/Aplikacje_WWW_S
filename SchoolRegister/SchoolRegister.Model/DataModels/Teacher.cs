using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher : User
    {
        public string Title {get; set;} = null!;

        public virtual IList<Subject>? Subjects {get;set;}

        //Teacher()
    }
}