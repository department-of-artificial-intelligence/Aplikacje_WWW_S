using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public GradeScale GradeValue { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}