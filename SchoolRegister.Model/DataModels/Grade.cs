using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels {
    public class Grade
    {
        public int Id {get;set;}
        public DateTime DateOfIssue { get; set; }
        public GradeScale GradeValue { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public virtual Parent Parent { get; set; }

        public Grade() {
            Subject = null!;
            Student = null!;
            Parent = null!;
        }
    }
}