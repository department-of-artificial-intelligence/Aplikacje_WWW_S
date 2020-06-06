using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Parent : User
    {
        public virtual IList<Student> Students { get; set; }
    }
}
