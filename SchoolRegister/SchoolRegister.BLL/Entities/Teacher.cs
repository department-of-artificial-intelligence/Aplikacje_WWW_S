using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Teacher : User
    {
        public virtual IList<Subject> Subjects { get; set; }
        public string Title { get; set; }
}
}
