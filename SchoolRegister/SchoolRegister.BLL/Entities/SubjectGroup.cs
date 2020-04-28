using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class SubjectGroup
    {
        public Group Group { get; set; }

        //[Key][ForeignKey("Group")]   //  jest w metodach
        public int GroupId { get; set; }

        public Subject Subject { get; set; }

        //[Key][ForeignKey("Subject")]  //  jest w metodach
        public int SubjectId { get; set; }
    }
}
