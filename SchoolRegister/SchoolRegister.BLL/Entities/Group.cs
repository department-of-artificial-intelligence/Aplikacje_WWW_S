using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[NotMapped]
        public virtual IList<Student> Students { get; set; }

        //[NotMapped]
        public virtual IList<SubjectGroup> SubjectGroups { get; set; }
    }
}
