using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SchoolRegister.Model.DataModels {
    public class Student
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
        public int ParentId { get; set; }
        public Parent Parent { get; set; } = null!;
        public IList<Grade> Grades { get; set; } = new List<Grade>();
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGradePerSubject { get; set; } = new Dictionary<string, double>();
        public IDictionary<string, IList<GradeScale>> GradesPerSubject { get; set; } = new Dictionary<string, IList<GradeScale>>();
    }
}