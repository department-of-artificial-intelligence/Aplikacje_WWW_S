using System;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public GradeScale GradeValue { get; set; }

        public int StudentId { get; set; } 
        public virtual Student Student { get; set; } = null!;

        public int SubjectId { get; set; } 
        public virtual Subject Subject { get; set; } = null!;
    }
}