using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRegister.Model.DataModels
{
    public class Grade
    {
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public GradeScale GradeValue {get;set;}
        public virtual Subject Subject {get;set;} = null!;
        public int SubjectId {get;set;}
        public virtual Student Student {get;set;} = null!;
        public int StudentId {get;set;}
    }
}