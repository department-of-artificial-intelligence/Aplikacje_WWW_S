using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Teacher:User
    {
        IList<Subject> Subjects { get; set; }
        string Title { get; set; }
    }
}