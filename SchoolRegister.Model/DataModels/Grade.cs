using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfIssue { get; set; }

        public GradeScale GradeValue { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; } = null!;

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;
    }
}
