using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Parent : User
    {
        IList<Student> Students { get; set; }
    }
}