using System;

namespace SchoolRegister.Model.DataModels
{
    public class Student
    {
        public double AverageGrade { get; set; }
        public IDictionary<string, double> AverageGradePerSubject { get;}
        public IList<Grade> Grades{ get; set; }
        public IDictionary<string, List<GradeScale>> GradesPerSubject {get;}
        public Group Group{ get; set; }
        public int? GroupId{ get; set; }
        public Parent Parent{ get; set; }
        public int? ParentID { get; set; }
    }
}