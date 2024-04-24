using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class SubjectGroup
    {
        public SubjectGroup() { }

        public virtual Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public virtual Group Group { get; set; }
        public int GroupId { get; set; }


    }
}