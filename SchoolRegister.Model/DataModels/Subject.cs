using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolRegister.Model.DataModels {
    public class Subject {
        [Key]
        public int Id {get;set;}
        public required string Name {get;set;}
        public required string Description {get;set;}
        public virtual IList<SubjectGroup> SubjectGroups { get; set; } = new List<SubjectGroup>();
        public virtual Teacher? Teacher {get;set;}
        [ForeignKey("Teacher")]
        public int? TeacherId {get;set;}
        public virtual IList<Grade> Grades { get; set; } = new List<Grade>();

    }
}