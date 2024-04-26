using Microsoft.AspNetCore.Identity;
using System;
namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public Group Group { get; set; } = null!;
        public int GroupId { get; set; } = null!;
        public IList<Grade> Grades { get; set; } = null!;
        public Parent Parent { get; set; } = null!;
        public int ParentId { get; set; } = null!;
        public double AvarageGrade { get; set; } = null!;
        public IDictionary<string, double> AvarageGradeSubject { get; set; } = null!;
        public IDictionary<string, List<GradeScale>> GradesPerSubject { get; set; } = null!;
    }
}