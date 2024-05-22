using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public Grade() { }
        public DateTime DateOfIssue { get; set; }

        public virtual GradeScale GradeValue { get; set; }

        public virtual Subject Subject { get; set; } = null!;

        public int SubjectId { get; set; }

        public virtual Student Student { get; set; } = null!;

        public int StudentId { get; set; }
    }
}