using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public DateTime DataOfIssue{get;set;}
        public GradeScale GradeValue{get;set;}
        public int SubjectId{get;set;}
        public int StudentId{get;set;}

        [ForeignKey("SubjectId")]
        public Subject Subject{get;set;}

        [ForeignKey("StudentId")]
        public Student Student{get;set;}

    }
}