using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace SchoolRegister.Model.DataModels
{
    public class Student : User
    {
        public double AverageGrade {get;}
        public IDictionary<string,double> AverageGradePerSubject {get;}
        public IList<Grade> Grades {get; set;}
        public Group Group {get; set;}
        public int? GroupId {get; set;}
        public Parent Parent {get; set;}
        public int? ParentId {get; set;}
    }
}