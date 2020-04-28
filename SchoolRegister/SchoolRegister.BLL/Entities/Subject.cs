using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolRegister.BLL.Entities
{
    public class Subject
    {
        [Required]
        public string Description { get; set; }

        //[NotMapped]
        public IList<Grade> Grades { get; set; }
        // public IList<Group> Groups { get; set; }  // zle przepisalem?

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[NotMapped]
        public IList<SubjectGroup> SubjectGroups { get; set; }

        
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
    }
}
