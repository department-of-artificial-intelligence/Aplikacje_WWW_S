using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Grade> Grades { get; set; }

        public virtual IList<SubjectGroup> SubjectGroups { get; set; }
        
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
    }
}
