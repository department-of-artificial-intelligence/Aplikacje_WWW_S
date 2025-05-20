using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Subject
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        
        public int? TeacherId { get; set; }  
        [ForeignKey("TeacherId")]
        public virtual Teacher? Teacher { get; set; }

         
        public virtual IList<Grade> Grades { get; set; }

        
        public virtual IList<SubjectGroup> SubjectGroups { get; set; }

        public Subject()
        {
            Grades = new List<Grade>();
            SubjectGroups = new List<SubjectGroup>();
        }
    }
}