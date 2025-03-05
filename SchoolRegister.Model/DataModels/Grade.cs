using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        DateTime DateOfIssue{ get; set; }
        GradeScale GradeValue { get; set; }
        Student Student { get; set; }
        int StudentId { get; set; }
        Subject Subject { get; set; }
        int SubjectId { get; set; }
    }
}