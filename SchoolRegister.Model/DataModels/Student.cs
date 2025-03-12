using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SchoolRegister.Model.DataModels
{
    public class Student: User
    {
        public double AverageGrade {get;}
        public IDictionary<string, double> AverageGradePerSubject{get;}
        public IList<Grade> Grades {get;set;}
        public  IDictionary <string, List<GradeSclae>> GradePerSubject {get;}
        public Group Group{get;set;}
        public int? GroupId{get;set;}
        public Parent Parent{get;set;}
        public int? ParentId {get;set;}
    }

}